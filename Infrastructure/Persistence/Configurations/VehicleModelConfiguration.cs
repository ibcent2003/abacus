using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.VehicleMakeId).IsRequired();
            builder.Property(x => x.IsActive);

        }
    }
}
