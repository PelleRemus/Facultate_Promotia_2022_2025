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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FeaturesPlatformDbContext).Assembly);
        }
    }
}
