using Microsoft.EntityFrameworkCore;

namespace FeaturesPlatform.Database
{
    public class FeaturesPlatformDbContext : DbContext
    {
        public FeaturesPlatformDbContext(DbContextOptions<FeaturesPlatformDbContext> options)
            : base(options)
        {
        }
    }
}
