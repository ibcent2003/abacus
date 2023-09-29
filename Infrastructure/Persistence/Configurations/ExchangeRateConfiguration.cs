using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Week).IsRequired();
            builder.Property(x => x.CurrencyId).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
