using FeaturesPlatform.Application.Common.Interfaces;
using FeaturesPlatform.Application.Features.Features.DTOs;

namespace FeaturesPlatform.Application.Features.Features.Queries
{
    public class GetFeaturesByProjectQueryHandler
    {
        private readonly IProjectRepository _projectRepository;

        public GetFeaturesByProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<FeatureDto>> Handle(GetFeaturesByProjectQuery query, CancellationToken ct)
        {
            var project = await _projectRepository.GetByIdAsync(query.ProjectId, ct);

            if (project is null)
                return new List<FeatureDto>();

            return project.Features.Select(f => new FeatureDto
            {
                Id = f.Id,
                Title = f.Title,
                Status = f.Status.ToString()
            }).ToList();
        }
    }
}
