namespace FeaturesPlatform.Domain.ValueObjects
{
    internal class ProjectName
    {
        public string Value { get; }

        public ProjectName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Project name cannot be empty");

            if (value.Length > 100)
                throw new ArgumentException("Project name too long");

            Value = value;
        }

        public override string ToString() => Value;
    }
}
