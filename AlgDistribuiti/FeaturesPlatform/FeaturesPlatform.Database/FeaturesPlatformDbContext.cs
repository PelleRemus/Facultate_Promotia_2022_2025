using FeaturesPlatform.Database.Entities;
using FeaturesPlatform.Domain.Aggregates.Project;
using Microsoft.EntityFrameworkCore;

namespace FeaturesPlatform.Database
{
    public class FeaturesPlatformDbContext : DbContext
    {
        public FeaturesPlatformDbContext(DbContextOptions<FeaturesPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
        public DbSet<InboxMessage> InboxMessages => Set<InboxMessage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FeaturesPlatformDbContext).Assembly);
        }
    }
}
