using FeaturesPlatform.Application.Common.DomainEvents;
using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Application.Common.Messaging;
using FeaturesPlatform.Application.Features.Features.Commands;
using FeaturesPlatform.Application.Features.Features.EventHandlers;
using FeaturesPlatform.Application.Features.Features.Queries;
using FeaturesPlatform.Database;
using FeaturesPlatform.Database.Repositories;
using FeaturesPlatform.Domain.Events;
using FeaturesPlatform.Infrastructure.Events;
using FeaturesPlatform.Infrastructure.Messaging;
using FeaturesPlatform.Infrastructure.Messaging.Outbox;
using FeaturesPlatform.Infrastructure.Messaging.RabbitMQ;
using FeaturesPlatform.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace FeaturesPlatform.Infrastructure.DependancyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FeaturesPlatformDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IOptions<OutboxOptions>, OptionsWrapper>();
            services.AddScoped<OutboxProcessor>();
            services.AddHostedService<OutboxBackgroundService>();
            services.AddHostedService<FeatureCreatedConsumer>();

            services.AddSingleton(sp =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672,
                };

                return factory.CreateConnectionAsync().GetAwaiter().GetResult();
            });
            services.AddScoped<IMessagePublisher, RabbitMqPublisher>();
            services.AddScoped<MessagingOptions>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddScoped<CreateFeatureCommandHandler>();
            services.AddScoped<GetFeaturesByProjectQueryHandler>();
            services.AddScoped<IDomainEventHandler<FeatureCreatedDomainEvent>, FeatureCreatedEventHandler>();

            return services;
        }
    }
}
