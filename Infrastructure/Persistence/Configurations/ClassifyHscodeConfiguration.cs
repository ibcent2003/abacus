using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ClassifyHscodeConfiguration : IEntityTypeConfiguration<ClassifyHscode>
    {
        public void Configure(EntityTypeBuilder<ClassifyHscode> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            //builder.Property(x => x.Heading).HasMaxLength(50);
            builder.Property(x => x.Description);
            builder.Property(x => x.StandardUnitOfQuantity).HasMaxLength(10); ;
            builder.Property(x => x.ImportDuty).HasMaxLength(10); ;
            builder.Property(x => x.VAT).HasMaxLength(10); ;
            builder.Property(x => x.NHIL).HasMaxLength(10);
            builder.Property(x => x.LVY).HasMaxLength(10);
            builder.Property(x => x.CountryId).IsRequired();
        }
    }
}
