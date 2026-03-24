using FeaturesPlatform.Application.Common.DomainEvents;
using FeaturesPlatform.Domain.Events;

namespace FeaturesPlatform.Application.Features.Features.EventHandlers
{
    public class FeatureCreatedEventHandler : IDomainEventHandler<FeatureCreatedDomainEvent>
    {
        public Task Handle(FeatureCreatedDomainEvent domainEvent, CancellationToken ct)
        {
            // For now just simulate behavior
            Console.WriteLine($"Feature created: {domainEvent.FeatureId}");

            return Task.CompletedTask;
        }
    }
}
