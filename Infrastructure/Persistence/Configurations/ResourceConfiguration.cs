using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {

            builder.Property(x => x.ResourcePage).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LocalLizationKey).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.PermissionId).IsRequired();
            builder.Property(x => x.Order).IsRequired();
        }
    }
}
