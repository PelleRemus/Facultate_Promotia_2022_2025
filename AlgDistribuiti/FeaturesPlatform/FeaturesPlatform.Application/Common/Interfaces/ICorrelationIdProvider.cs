namespace FeaturesPlatform.Application.Common.Interfaces
{
    public interface ICorrelationIdProvider
    {
        Guid CorrelationId { get; set; }
    }
}
