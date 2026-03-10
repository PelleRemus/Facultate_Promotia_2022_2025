using FeaturesPlatform.Domain.Events;

namespace FeaturesPlatform.Domain.Common
{
    public class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void RaiseEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
