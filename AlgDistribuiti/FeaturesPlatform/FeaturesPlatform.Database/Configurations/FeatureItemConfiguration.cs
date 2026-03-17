using FeaturesPlatform.Domain.Aggregates.Feature;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FeaturesPlatform.Database.Configurations
{
    public class FeatureItemConfiguration : IEntityTypeConfiguration<FeatureItem>
    {
        public void Configure(EntityTypeBuilder<FeatureItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Status)
                   .HasConversion<string>();
        }
    }
}
