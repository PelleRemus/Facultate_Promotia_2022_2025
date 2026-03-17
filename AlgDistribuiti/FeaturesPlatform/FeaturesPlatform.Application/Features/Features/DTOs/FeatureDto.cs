namespace FeaturesPlatform.Application.Features.Features.DTOs
{
    public class FeatureDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
