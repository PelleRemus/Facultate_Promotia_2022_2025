namespace FeaturesPlatform.Application.Features.Features.Commands
{
    public record CreateFeatureCommand(
        Guid ProjectId,
        string Title
    );
}
