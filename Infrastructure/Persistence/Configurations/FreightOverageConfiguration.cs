using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class FreightOverageConfiguration : IEntityTypeConfiguration<FreightOverage>
    {
        public void Configure(EntityTypeBuilder<FreightOverage> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.VehicleTypeId).IsRequired();
            builder.Property(x => x.OverAgeName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.OverAgeRate).IsRequired();
            builder.Property(x => x.MinimumAge).IsRequired();
            builder.Property(x => x.MaximumAge).IsRequired();
            builder.Property(x => x.FreightName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.MinimumCC).IsRequired();
            builder.Property(x => x.MaximumAge).IsRequired();
            builder.Property(x => x.HsCode).IsRequired().HasMaxLength(20);
        }
    }
}
