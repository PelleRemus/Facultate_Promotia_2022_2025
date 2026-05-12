using FeaturesPlatform.Application.Common.Interfaces;

namespace FeaturesPlatform.Application.Common
{
    public class HttpCorrelationIdProvider : ICorrelationIdProvider
    {
        public Guid CorrelationId { get; set; }
    }
}
