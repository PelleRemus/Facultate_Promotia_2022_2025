using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FeaturesPlatform.Infrastructure.Messaging.Outbox
{
    public class OutboxBackgroundService : BackgroundService
    {
        private const int milisecondsInSecond = 1000;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IOptions<OutboxOptions> _options;

        public OutboxBackgroundService(IServiceProvider serviceProvider/*, IOptions<OutboxOptions> options*/)
        {
            _serviceProvider = serviceProvider;
            //_options = options;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var processor = scope.ServiceProvider.GetRequiredService<OutboxProcessor>();

                await processor.ProcessAsync(stoppingToken);

                await Task.Delay(5 * milisecondsInSecond, stoppingToken);
            }
        }
    }
}