using FeaturesPlatform.Domain.Aggregates.Feature;
using FeaturesPlatform.Domain.Common;
using FeaturesPlatform.Domain.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeaturesPlatform.Domain.Aggregates.Project
{
    public class Project : AggregateRoot
    {
        private readonly List<FeatureItem> _features = new();
        public const string featuresFieldName = nameof(_features);

        public string Name { get; private set; }

        [NotMapped]
        public IReadOnlyCollection<FeatureItem> Features => _features;

        private Project() { }
        public Project(string name)
        {
            Name = name;
        }

        public FeatureItem CreateFeature(string title)
        {
            var feature = new FeatureItem(title);
            _features.Add(feature);

            RaiseEvent(new FeatureCreatedDomainEvent(feature.Id, Id));
            return feature;
        }
    }
}
