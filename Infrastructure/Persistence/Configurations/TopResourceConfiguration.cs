using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class TopResourceConfiguration : IEntityTypeConfiguration<TopResource>
    {
        public void Configure(EntityTypeBuilder<TopResource> builder)
        {
            builder.Property(x => x.ResourceName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LocalizationKey).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Order).IsRequired();
        }
    }
}
