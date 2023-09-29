using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class AgencyConfiguration : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.AgencyName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.logo).HasMaxLength(100);
            builder.Property(x => x.AgencyCode).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
