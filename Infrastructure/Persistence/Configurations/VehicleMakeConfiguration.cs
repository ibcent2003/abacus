using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class VehicleMakeConfiguration : IEntityTypeConfiguration<VehicleMake>
    {
        public void Configure(EntityTypeBuilder<VehicleMake> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.MakeName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive);
        }


    }
}
