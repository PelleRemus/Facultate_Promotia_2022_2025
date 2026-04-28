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

            // Pentru mesajele normale
            var exchange = "features.events";
            var queue = "features.created";

            await channel.ExchangeDeclareAsync(
                exchange: exchange,
                type: ExchangeType.Fanout,
                durable: true,
                autoDelete: false,
                cancellationToken: stoppingToken);

            await channel.QueueDeclareAsync(
                queue: queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: stoppingToken);

            await channel.QueueBindAsync(
                queue: queue,
                exchange: exchange,
                routingKey: string.Empty,
                cancellationToken: stoppingToken);

            // Pentru mesajele care nu pot fi procesate (DLQ)
            exchange = "features.dlq";
            queue = "features.events.dlq";

            await channel.ExchangeDeclareAsync(
                exchange: exchange,
                type: "fanout");

            await channel.QueueDeclareAsync(
                queue: queue,
                durable: true,
                exclusive: false,
                autoDelete: false);

            await channel.QueueBindAsync(
                queue: queue,
                exchange: exchange,
                routingKey: "");

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, args) =>
            {
                var json = Encoding.UTF8.GetString(args.Body.ToArray());
                var @event = JsonSerializer.Deserialize<FeatureCreatedDomainEvent>(json);

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

                using var transaction = await dbContext.Database.BeginTransactionAsync();
                try
                {
                    // 1. Save Inbox record if needed
                    if (inboxMessage == null)
                    {
                        dbContext.InboxMessages.Add(new InboxMessage
                        {
                            Id = @event!.Id,
                            ReceivedAt = DateTime.UtcNow,
                            Type = @event!.GetType().FullName!,
                            RetryCount = 0
                        });
                    }

                    // 2. Handle event
                    await handler.Handle(@event!, stoppingToken);

                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    await channel.BasicAckAsync(args.DeliveryTag, false);
                }
                catch
                {
                    inboxMessage.RetryCount++;
                    await dbContext.SaveChangesAsync();

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

            await channel.BasicConsumeAsync(
                queue: queue,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            // keep the background service alive
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
