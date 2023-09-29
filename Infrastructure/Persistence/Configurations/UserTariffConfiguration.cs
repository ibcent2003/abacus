using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class UserTariffConfiguration : IEntityTypeConfiguration<UserTariff>
    {
        public void Configure(EntityTypeBuilder<UserTariff> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HsCodePoolId).IsRequired();
            builder.Property(x => x.HSCodeTariffTaxId).IsRequired();
            builder.Property(x => x.TariffValue).IsRequired();
            builder.Property(x => x.IsRate).IsRequired();
            builder.Property(x => x.TransactionId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
