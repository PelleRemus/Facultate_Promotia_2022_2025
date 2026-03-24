using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Database;
using FeaturesPlatform.Domain.Common;
using System.Text.Json;

namespace FeaturesPlatform.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FeaturesPlatformDbContext _context;
        private readonly IDomainEventDispatcher _dispatcher;

        public UnitOfWork(FeaturesPlatformDbContext context, IDomainEventDispatcher dispatcher)
        {
            _context = context;
            _dispatcher = dispatcher;
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            // 1. Extract domain events
            var domainEntities = _context.ChangeTracker  // Din modificarile facute la DB,
                .Entries<AggregateRoot>()                // Luam obiectele de tip AggregateRoot
                .Where(x => x.Entity.DomainEvents.Any()) // Care au domain events
                .Select(x => x.Entity)                   // Mapam la entitate (clasa din C#, nu cea abstracta din DB)
                .ToList();

            var events = domainEntities
                .SelectMany(x => x.DomainEvents)
                .ToList();

            // 2. Convert to outbox messages
            var outboxMessages = events.Select(e => new OutboxMessage
            {
                Id = Guid.NewGuid(),
                Type = e.GetType().Name,
                Payload = JsonSerializer.Serialize(e),
                OccurredOn = e.OccurredOn
            }).ToList();

            await _context.OutboxMessages.AddRangeAsync(outboxMessages, ct);

            // 3. Clear events
            domainEntities.ForEach(x => x.ClearEvents());

            // 4. Save to DB
            await _context.SaveChangesAsync(ct);
        }
    }
}
