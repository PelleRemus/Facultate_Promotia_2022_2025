using FeaturesPlatform.Application.Common.Messaging;
using FeaturesPlatform.Domain.Common;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FeaturesPlatform.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMqPublisher : IMessagePublisher
    {
        private readonly IConnection _connection;

        public RabbitMqPublisher(IConnection connection)
        {
            _connection = connection;
        }

        public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct)
        {
            await using var channel = await _connection.CreateChannelAsync();

            var exchange = "features.events";

            await channel.ExchangeDeclareAsync(
                exchange: exchange,
                type: ExchangeType.Fanout,
                durable: true,
                autoDelete: false,
                cancellationToken: ct);

            var json = JsonSerializer.Serialize(domainEvent, domainEvent.GetType());
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: exchange,
                routingKey: string.Empty,
                body: body,
                cancellationToken: ct);
        }
    }
}
