using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class FreightRateConfiguration : IEntityTypeConfiguration<FreightRate>
    {
        public void Configure(EntityTypeBuilder<FreightRate> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.VehicleCategoryId).IsRequired();
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.MinimumCC);
            builder.Property(x => x.MaximumCC);

        }
    }
}
