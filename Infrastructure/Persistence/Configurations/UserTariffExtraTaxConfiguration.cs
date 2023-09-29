using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class UserTariffExtraTaxConfiguration : IEntityTypeConfiguration<UserTariffExtraTax>
    {
        public void Configure(EntityTypeBuilder<UserTariffExtraTax> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.TaxName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TaxValue).IsRequired();
            builder.Property(x => x.UserHSCodePoolId).IsRequired();
            builder.Property(x => x.TransactionId).IsRequired();
            builder.Property(x => x.IsRate).IsRequired();
        }
    }
}
