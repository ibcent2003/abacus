using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class HSCodeTariffConfiguration : IEntityTypeConfiguration<HSCodeTariff>
    {
        public void Configure(EntityTypeBuilder<HSCodeTariff> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HsCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.HeadingId).IsRequired();
            builder.Property(x => x.QuestionId);
            builder.Property(x => x.HeaderId).IsRequired();
            builder.Property(x => x.Flow).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Photo).HasMaxLength(100);
            builder.Property(x => x.Description);
            builder.Property(x => x.LegalNote);

        }
    }
}
