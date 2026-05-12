namespace FeaturesPlatform.Domain.Common
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        Guid CorrelationId { get; }
        DateTime OccurredOn { get; }
    }
}
