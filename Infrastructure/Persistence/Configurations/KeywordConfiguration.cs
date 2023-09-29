using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.RelatedName);
            builder.Property(x => x.HeadingId).IsRequired();
            builder.Property(x => x.IsFinal).IsRequired();
            builder.Property(x => x.ModifiedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedBy).IsRequired();
           
        }
    }
}
