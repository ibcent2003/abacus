using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class TariffBenchmarkConfiguration : IEntityTypeConfiguration<TariffBenchmark>
    {
        public void Configure(EntityTypeBuilder<TariffBenchmark> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HSCode).HasMaxLength(20);
            builder.Property(x => x.keywords);
            builder.Property(x => x.CountryName);
            builder.Property(x => x.Code).HasMaxLength(10);
            builder.Property(x => x.ProductValue);
            builder.Property(x => x.Unit);
            builder.Property(x => x.Packaging);
            builder.Property(x => x.Qty);
            builder.Property(x => x.SUOM);
            builder.Property(x => x.UnitFOB);
        }
    }
}
