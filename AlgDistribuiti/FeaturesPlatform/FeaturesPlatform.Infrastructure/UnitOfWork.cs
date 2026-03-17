using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Database;

namespace FeaturesPlatform.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FeaturesPlatformDbContext _context;

        public UnitOfWork(FeaturesPlatformDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
