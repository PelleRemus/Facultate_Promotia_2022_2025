using FeaturesPlatform.Application.Common.Interfaces;

namespace FeaturesPlatform.Application.Features.Features.Commands
{
    public class CreateFeatureCommandHandler
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFeatureCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateFeatureCommand command, CancellationToken ct)
        {
            var project = await _projectRepository.GetByIdAsync(command.ProjectId, ct);

            if (project is null)
                throw new KeyNotFoundException($"Project with id '{command.ProjectId}' not found");

            var feature = project.CreateFeature(command.Title);
            await _unitOfWork.SaveChangesAsync(ct);

            return feature.Id;
        }
    }
}
