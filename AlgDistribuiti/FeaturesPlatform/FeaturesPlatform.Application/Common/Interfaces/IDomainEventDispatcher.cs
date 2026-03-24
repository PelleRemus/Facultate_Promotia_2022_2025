using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Application.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken);
    }
}
