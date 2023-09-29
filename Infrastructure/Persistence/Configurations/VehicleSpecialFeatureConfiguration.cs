using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class VehicleSpecialFeatureConfiguration : IEntityTypeConfiguration<VehicleSpecialFeature>
    {
        public void Configure(EntityTypeBuilder<VehicleSpecialFeature> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SpecialFeatureName).IsRequired().HasMaxLength(10);
            builder.Property(x => x.VehicleMakeId).IsRequired();
            builder.Property(x => x.IsActive);
        }
    }
}
