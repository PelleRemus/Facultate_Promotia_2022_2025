using FeaturesPlatform.Application.Common.DomainEvents;
using FeaturesPlatform.Domain.Events;
using Microsoft.Extensions.Logging;

namespace FeaturesPlatform.Application.Features.Features.EventHandlers
{
    public class FeatureCreatedEventHandler : IDomainEventHandler<FeatureCreatedDomainEvent>
    {
        private readonly ILogger<FeatureCreatedEventHandler> _logger;

        public FeatureCreatedEventHandler(ILogger<FeatureCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FeatureCreatedDomainEvent domainEvent, CancellationToken ct)
        {
            // For now just simulate behavior
            _logger.LogInformation($"Handled event {domainEvent.Id}, with correlation Id {domainEvent.CorrelationId}");
            _logger.LogInformation($"Feature created: {domainEvent.FeatureId}");
            Console.WriteLine($"Feature created: {domainEvent.FeatureId}");

            return Task.CompletedTask;
        }
    }
}
