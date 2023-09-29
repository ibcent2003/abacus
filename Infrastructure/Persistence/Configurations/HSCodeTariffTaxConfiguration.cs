using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class HSCodeTariffTaxConfiguration : IEntityTypeConfiguration<HSCodeTariffTax>
    {
        public void Configure(EntityTypeBuilder<HSCodeTariffTax> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.TaxName).IsRequired().HasMaxLength(50);        
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
