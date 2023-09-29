using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class HSCodePoolConfiguration : IEntityTypeConfiguration<HSCodePool>
    {
        public void Configure(EntityTypeBuilder<HSCodePool> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HSCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Heading).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.StandardUnitOfQuantity).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
