using System.Text.Json.Serialization;

namespace FeaturesPlatform.Domain.Aggregates.Feature
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FeatureStatus
    {
        Open,
        InProgress,
        Completed
    }
}
