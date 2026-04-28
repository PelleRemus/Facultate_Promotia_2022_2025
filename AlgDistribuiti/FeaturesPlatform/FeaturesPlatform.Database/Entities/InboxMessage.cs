using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Database.Entities
{
    public class InboxMessage : Entity
    {
        public DateTime ReceivedAt { get; set; }
        public string Type { get; set; } = default!;
        public int RetryCount { get; set; }
    }
}
