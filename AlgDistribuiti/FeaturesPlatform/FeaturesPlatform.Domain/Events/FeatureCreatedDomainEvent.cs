using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Domain.Events
{
    public class FeatureCreatedDomainEvent : IDomainEvent
    {
        public Guid Id { get; set; }

        public Guid FeatureId { get; }

        public Guid ProjectId { get; }

        public DateTime OccurredOn { get; }

        public FeatureCreatedDomainEvent(Guid featureId, Guid projectId)
        {
            Id = Guid.NewGuid();
            FeatureId = featureId;
            ProjectId = projectId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
