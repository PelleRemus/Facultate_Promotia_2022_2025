using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Database;
using FeaturesPlatform.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace FeaturesPlatform.Infrastructure.Messaging.Outbox
{
    public class OutboxProcessor : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public OutboxProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<FeaturesPlatformDbContext>();
                var dispatcher = scope.ServiceProvider.GetRequiredService<IDomainEventDispatcher>();

                var messages = await context.OutboxMessages
                    .Where(x => x.ProcessedOn == null)
                    .Take(20)
                    .ToListAsync(stoppingToken);

                foreach (var message in messages)
                {
                    var type = Type.GetType(message.Type); // sau:   e.GetType().AssemblyQualifiedName

                    if (type is null)
                        continue;

                    var domainEvent = (IDomainEvent)JsonSerializer.Deserialize(message.Payload, type)!;

                    await dispatcher.DispatchAsync([domainEvent], stoppingToken);

                    message.ProcessedOn = DateTime.UtcNow;
                }

                await context.SaveChangesAsync(stoppingToken);

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
