using FeaturesPlatform.Application.Features.Features.EventHandlers;
using FeaturesPlatform.Domain.Events;
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

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, args) =>
            {
                var json = Encoding.UTF8.GetString(args.Body.ToArray());
                var @event = JsonSerializer.Deserialize<FeatureCreatedDomainEvent>(json);

                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<FeatureCreatedEventHandler>();

                await handler.Handle(@event!, stoppingToken);
                await channel.BasicAckAsync(args.DeliveryTag, multiple: false, stoppingToken);
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
