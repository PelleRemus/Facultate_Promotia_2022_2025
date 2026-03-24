using FeaturesPlatform.Application.Common.DomainEvents;
using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Domain.Common;
using Microsoft.Extensions.DependencyInjection;

namespace FeaturesPlatform.Infrastructure.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IDomainEventHandler<>)
                    .MakeGenericType(domainEvent.GetType());

                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    var method = handlerType.GetMethod("Handle");

                    await (Task)method!.Invoke(handler, new object[] { domainEvent, cancellationToken })!;
                }
            }
        }
    }
}
