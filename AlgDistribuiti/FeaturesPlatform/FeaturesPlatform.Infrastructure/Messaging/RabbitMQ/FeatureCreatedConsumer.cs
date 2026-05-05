using FeaturesPlatform.Application.Common.DomainEvents;
using FeaturesPlatform.Database;
using FeaturesPlatform.Database.Entities;
using FeaturesPlatform.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace FeaturesPlatform.Infrastructure.Messaging.RabbitMQ
{
    public class FeatureCreatedConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;

        public FeatureCreatedConsumer(IServiceProvider serviceProvider, IConnection connection)
        {
            _serviceProvider = serviceProvider;
            _connection = connection;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using var channel = await _connection.CreateChannelAsync();

            // Pentru mesajele care nu pot fi procesate (DLQ)
            var dlqExchange = "features.dlq";
            var dlqQueue = "features.events.dlq";
            var args = new Dictionary<string, object>
            {
                { "x-dead-letter-exchange", dlqExchange }
            };

            await channel.ExchangeDeclareAsync(dlqExchange, ExchangeType.Fanout);
            await channel.QueueDeclareAsync(dlqQueue, true, false, false);
            await channel.QueueBindAsync(dlqQueue, dlqExchange, string.Empty);

            // Pentru mesajele normale
            var mainExchange = "features.events";
            var mainQueue = "features.created";

            await channel.ExchangeDeclareAsync(mainExchange, ExchangeType.Fanout, true);
            await channel.QueueDeclareAsync(mainQueue, true, false, false, arguments: args);
            await channel.QueueBindAsync(mainQueue, mainExchange, string.Empty);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, args) =>
            {
                var json = Encoding.UTF8.GetString(args.Body.ToArray());
                var @event = Newtonsoft.Json.JsonConvert.DeserializeObject<FeatureCreatedDomainEvent>(json);

                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<IDomainEventHandler<FeatureCreatedDomainEvent>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<FeaturesPlatformDbContext>();
                var options = scope.ServiceProvider.GetRequiredService<MessagingOptions>();

                // Check the inbox first
                var inboxMessage = await dbContext.InboxMessages.FirstOrDefaultAsync(x => x.Id == @event!.Id);
                if (inboxMessage != null && inboxMessage.RetryCount > options.MaxRetryCount)
                {
                    // already exceeded retries → ACK and ignore
                    await channel.BasicAckAsync(args.DeliveryTag, false, stoppingToken);
                    return;
                }

                // 1. Save Inbox record if needed
                if (inboxMessage == null)
                {
                    inboxMessage = new InboxMessage
                    {
                        Id = @event!.Id,
                        ReceivedAt = DateTime.UtcNow,
                        Type = @event!.GetType().FullName!,
                        RetryCount = 0
                    };
                    dbContext.InboxMessages.Add(inboxMessage);
                }
                await dbContext.SaveChangesAsync();

                using var transaction = await dbContext.Database.BeginTransactionAsync();
                try
                {
                    // 2. Handle event
                    await handler.Handle(@event!, stoppingToken);
                    throw new Exception("Simulated failure"); // for testing retry and DLQ

                    await transaction.CommitAsync();
                    await channel.BasicAckAsync(args.DeliveryTag, false);
                }
                catch
                {
                    if (inboxMessage == null)
                    {
                        return;
                    }
                    inboxMessage.RetryCount++;
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    if (inboxMessage.RetryCount >= options.MaxRetryCount)
                    {
                        // ❌ send to DLQ
                        await channel.BasicRejectAsync(args.DeliveryTag, requeue: false);
                    }
                    else
                    {
                        // 🔁 retry
                        await channel.BasicNackAsync(args.DeliveryTag, false, requeue: true);
                    }
                }
            };
            await channel.BasicConsumeAsync(queue: mainQueue, autoAck: false, consumer: consumer, cancellationToken: stoppingToken);

            // keep the background service alive
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
