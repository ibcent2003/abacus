
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class CalculatedDutyConfiguration : IEntityTypeConfiguration<CalculatedDuty>
    {
        public void Configure(EntityTypeBuilder<CalculatedDuty> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.VehicleType).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ChassisNo).IsRequired();
            builder.Property(x => x.VehicleMake).IsRequired();
            builder.Property(x => x.VehicleModel).IsRequired();
            builder.Property(x => x.YearOfManufacture).IsRequired();
            builder.Property(x => x.HDV).IsRequired();
            builder.Property(x => x.CC).IsRequired();
            builder.Property(x => x.DepreciationAllow).IsRequired();
            builder.Property(x => x.FOB).IsRequired();
            builder.Property(x => x.Freight).IsRequired();
            builder.Property(x => x.Insurance).IsRequired();
            builder.Property(x => x.CIFForginCurrency).IsRequired();
            builder.Property(x => x.CurrencyName).IsRequired();
            builder.Property(x => x.ExchangeRate).IsRequired();
            builder.Property(x => x.CIFLocalCurrency).IsRequired();
            builder.Property(x => x.HsCode).IsRequired();
            builder.Property(x => x.ImportDuty).IsRequired();
            builder.Property(x => x.ProcessingFee).IsRequired();
            builder.Property(x => x.VAT).IsRequired();
            builder.Property(x => x.Shipper).IsRequired();
            builder.Property(x => x.NHIL).IsRequired();
            builder.Property(x => x.InterestCharge).IsRequired();
            builder.Property(x => x.Ecowas).IsRequired();
            builder.Property(x => x.NetworkCharge).IsRequired();
            builder.Property(x => x.EXIM).IsRequired();
            builder.Property(x => x.NetChargeVAT).IsRequired();
            builder.Property(x => x.ExamFee).IsRequired();
            builder.Property(x => x.NetChargeNHIL).IsRequired();
            builder.Property(x => x.SpecialImpLevy).IsRequired();
            builder.Property(x => x.OverAgePenalty).IsRequired();
            builder.Property(x => x.TotalDutyAfterDeduction).IsRequired();
            builder.Property(x => x.TotalDutyBeforeDeduction).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.TransactionId).IsRequired();
            builder.Property(x => x.SpecialFeatures).HasMaxLength(20);
            builder.Property(x => x.NoOfDoors);
            builder.Property(x => x.SeatingCapacity);
            builder.Property(x => x.FuelType).HasMaxLength(10);
            builder.Property(x => x.Color).HasMaxLength(15);
            builder.Property(x => x.CountryId).IsRequired();

        }
    }
}
