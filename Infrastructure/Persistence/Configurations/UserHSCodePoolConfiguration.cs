using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class UserHSCodePoolConfiguration : IEntityTypeConfiguration<UserHSCodePool>
    {
        public void Configure(EntityTypeBuilder<UserHSCodePool> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HsCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.FOB).IsRequired();
            builder.Property(x => x.Freight).IsRequired();
            builder.Property(x => x.Insurance).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CurrencyId);
            builder.Property(x => x.TransactionDate);
            builder.Property(x => x.TransactionId);
            builder.Property(x => x.UserId);
            builder.Property(x => x.StandardUnitOfQuantity);
            builder.Property(x => x.ExportingCountryId);
            builder.Property(x => x.Keyword);
            builder.Property(x => x.ContainerSize);
        }
    }
}
