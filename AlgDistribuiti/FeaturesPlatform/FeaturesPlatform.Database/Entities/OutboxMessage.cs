using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Database.Entities
{
    public class OutboxMessage : Entity
    {
        public string Type { get; set; } = default!;

        public string Payload { get; set; } = default!;

        public DateTime OccurredOn { get; set; }

        public DateTime? ProcessedOn { get; set; }
    }
}
