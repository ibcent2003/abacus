using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class VehicleSearchPoolConfiguration : IEntityTypeConfiguration<VehicleSearchPool>
    {
        public void Configure(EntityTypeBuilder<VehicleSearchPool> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.MakeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.VehicleTypeName).IsRequired().HasMaxLength(50); ;
            builder.Property(x => x.SpecialFeatureName).IsRequired().HasMaxLength(10); ;
            builder.Property(x => x.SeatingCapacity).IsRequired().HasMaxLength(10); ;
            builder.Property(x => x.EngineCapacity).IsRequired().HasMaxLength(10);
            builder.Property(x => x.FuelType).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Year).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.OwnedBy).HasMaxLength(50);
            builder.Property(x => x.CurrencyName).HasMaxLength(20);
            builder.Property(x => x.HDV).HasMaxLength(50);
            builder.Property(x => x.TransactonDate).IsRequired();
            builder.Property(x => x.TransactionId).IsRequired();
            builder.Property(x => x.Status).HasMaxLength(50);
            builder.Property(x => x.DutyResult);
            builder.Property(x => x.CalculatedBy).HasMaxLength(50);
            builder.Property(x => x.CalculatedDate);
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.ChassisNo).HasMaxLength(50);
            builder.Property(x => x.AssessedHSCode).HasMaxLength(50);
            builder.Property(x => x.NoOfDoor);
        }
    }
}
