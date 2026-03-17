using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Domain.Aggregates.Project;
using Microsoft.EntityFrameworkCore;

namespace FeaturesPlatform.Database.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly FeaturesPlatformDbContext _context;

        public ProjectRepository(FeaturesPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<Project?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Projects
                .Include(Project.featuresFieldName)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task AddAsync(Project project, CancellationToken ct)
        {
            await _context.Projects.AddAsync(project, ct);
        }
    }
}
