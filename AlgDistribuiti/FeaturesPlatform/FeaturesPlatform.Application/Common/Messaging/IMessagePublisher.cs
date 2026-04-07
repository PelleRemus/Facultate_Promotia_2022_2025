using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Application.Common.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct);
    }
}
