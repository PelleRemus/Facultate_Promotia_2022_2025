using Microsoft.Extensions.Options;

namespace FeaturesPlatform.Infrastructure.Messaging.Outbox
{
    public class OptionsWrapper : IOptions<OutboxOptions>
    {
        public OutboxOptions Value { get; set; } = new OutboxOptions();
    }
    public class OutboxOptions
    {
        public int IntervalInSeconds { get; set; } = 5;
        public int BatchSize { get; set; } = 20;
    }
}
