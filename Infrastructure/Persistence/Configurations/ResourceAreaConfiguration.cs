using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ResourceAreaConfiguration : IEntityTypeConfiguration<ResourceArea>
    {
        public void Configure(EntityTypeBuilder<ResourceArea> builder)
        {
            builder.Property(x => x.ParentId).IsRequired();
            builder.Property(x => x.IconUrl).HasMaxLength(40);
            builder.Property(x => x.AreaName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LocalizationKey).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Order).IsRequired();
        }
    }
}
