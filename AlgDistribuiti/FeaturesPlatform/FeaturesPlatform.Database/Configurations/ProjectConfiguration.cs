using FeaturesPlatform.Domain.Aggregates.Feature;
using FeaturesPlatform.Domain.Aggregates.Project;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FeaturesPlatform.Database.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(typeof(FeatureItem), Project.featuresFieldName)
                   .WithOne()
                   .HasForeignKey("ProjectId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
