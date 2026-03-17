using FeaturesPlatform.Domain.Aggregates.Project;

namespace FeaturesPlatform.Application.Common.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Project project, CancellationToken cancellationToken);
    }
}
