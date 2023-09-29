using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class SubQuestionConfiguration : IEntityTypeConfiguration<SubQuestion>
    {
        public void Configure(EntityTypeBuilder<SubQuestion> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.HeadingId).IsRequired();
            builder.Property(x => x.SetupTypeId).IsRequired();
            builder.Property(x => x.Category).HasMaxLength(50);
            builder.Property(x => x.IsFinal).IsRequired();
            builder.Property(x => x.ModifiedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedBy).IsRequired();   
        }
    }
}
