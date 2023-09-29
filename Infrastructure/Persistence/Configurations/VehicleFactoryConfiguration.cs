using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class VehicleFactoryConfiguration : IEntityTypeConfiguration<VehicleFactory>
    {
        public void Configure(EntityTypeBuilder<VehicleFactory> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.MakeName).IsRequired();
            builder.Property(x => x.ModelName).IsRequired();
            builder.Property(x => x.ChassisNo).HasMaxLength(50);
            builder.Property(x => x.AssessedHSCode).HasMaxLength(50);

            builder.Property(x => x.Condition).HasMaxLength(50);
            builder.Property(x => x.SpecialFeatures).HasMaxLength(50);
            builder.Property(x => x.NoOfDoors);
            builder.Property(x => x.ManufactureYear).HasMaxLength(50);
            builder.Property(x => x.EngineCapacity).HasMaxLength(50);


            builder.Property(x => x.HDV);
            builder.Property(x => x.VehicleType).IsRequired();
            builder.Property(x => x.Currency).HasMaxLength(50);
            builder.Property(x => x.SeatingCapacity);
            builder.Property(x => x.FuelType).HasMaxLength(50);
            builder.Property(x => x.Colour).HasMaxLength(50);
        }
    }
}
