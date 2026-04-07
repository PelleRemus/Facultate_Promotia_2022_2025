using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Application.Common.Messaging;
using FeaturesPlatform.Database;
using FeaturesPlatform.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FeaturesPlatform.Infrastructure.Messaging.Outbox
{
    public class OutboxProcessor
    {
        private readonly FeaturesPlatformDbContext _context;
        private readonly IMessagePublisher _publisher;
        //private readonly IDomainEventDispatcher _dispatcher;
        //private readonly IOptions<OutboxOptions> _options;

        public OutboxProcessor(FeaturesPlatformDbContext context, IMessagePublisher publisher
            /*IDomainEventDispatcher dispatcher, IOptions<OutboxOptions> options*/)
        {
            _context = context;
            _publisher = publisher;
            //_dispatcher = dispatcher;
            //_options = options;
        }

        public async Task ProcessAsync(CancellationToken ct)
        {
            var messages = await _context.OutboxMessages
                .Where(x => x.ProcessedOn == null)
                .OrderBy(x => x.OccurredOn)
                .Take(20)
                .ToListAsync(ct);

            foreach (var message in messages)
            {
                var type = Type.GetType(message.Type);

                if (type is null)
                    continue;

                var domainEvent = (IDomainEvent)JsonSerializer.Deserialize(message.Payload, type)!;

                await _publisher.PublishAsync(domainEvent, ct);

                message.ProcessedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync(ct);
        }
    }
}
