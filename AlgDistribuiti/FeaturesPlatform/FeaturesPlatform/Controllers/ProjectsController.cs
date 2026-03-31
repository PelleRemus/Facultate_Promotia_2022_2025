using FeaturesPlatform.API.Requests;
using FeaturesPlatform.Application.Features.Features.Commands;
using FeaturesPlatform.Application.Features.Features.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FeaturesPlatform.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly CreateFeatureCommandHandler _createFeatureHandler;
        private readonly GetFeaturesByProjectQueryHandler _getProjectHandler;

        public ProjectsController(
            CreateFeatureCommandHandler createFeatureHandler,
            GetFeaturesByProjectQueryHandler getProjectHandler)
        {
            _createFeatureHandler = createFeatureHandler;
            _getProjectHandler = getProjectHandler;
        }

        [HttpGet("{projectId}/features")]
        public async Task<IActionResult> GetProjectFeatures(Guid projectId, CancellationToken ct)
        {
            var result = await _getProjectHandler.Handle(new GetFeaturesByProjectQuery(projectId), ct);

            return Ok(result);
        }

        [HttpPost("{projectId}/features")]
        public async Task<IActionResult> CreateFeature(Guid projectId, [FromBody] CreateFeatureRequest request, CancellationToken ct)
        {
            var command = new CreateFeatureCommand(projectId, request.Title);

            var featureId = await _createFeatureHandler.Handle(command, ct);

            return Ok(featureId);
        }
    }
}
