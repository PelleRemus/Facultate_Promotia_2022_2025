using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Application.Common.DomainEvents
{
    public interface IDomainEventHandler<TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent, CancellationToken cancellationToken);
    }
}
