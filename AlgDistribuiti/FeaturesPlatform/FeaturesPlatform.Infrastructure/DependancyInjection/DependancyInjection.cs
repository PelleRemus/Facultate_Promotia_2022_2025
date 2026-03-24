using FeaturesPlatform.Application.Common.DomainEvents;
using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Application.Features.Features.EventHandlers;
using FeaturesPlatform.Database;
using FeaturesPlatform.Database.Repositories;
using FeaturesPlatform.Domain.Events;
using FeaturesPlatform.Infrastructure.Events;
using FeaturesPlatform.Infrastructure.Messaging.Outbox;
using FeaturesPlatform.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddHostedService<OutboxProcessor>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddScoped<IDomainEventHandler<FeatureCreatedDomainEvent>, FeatureCreatedEventHandler>();

            return services;
        }
    }
}
