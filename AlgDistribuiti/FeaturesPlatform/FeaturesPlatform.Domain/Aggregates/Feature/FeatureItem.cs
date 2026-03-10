using FeaturesPlatform.Domain.Common;

namespace FeaturesPlatform.Domain.Aggregates.Feature
{
    public class FeatureItem : Entity
    {
        public string Title { get; private set; }

        public FeatureStatus Status { get; private set; }

        internal FeatureItem(string title)
        {
            Title = title;
            Status = FeatureStatus.Open;
        }

        public void Start()
        {
            if (Status != FeatureStatus.Open)
                throw new InvalidOperationException("Task cannot be started.");

            Status = FeatureStatus.InProgress;
        }

        public void Complete()
        {
            if (Status == FeatureStatus.Completed)
                throw new InvalidOperationException("Task already completed.");

            Status = FeatureStatus.Completed;
        }
    }
}
