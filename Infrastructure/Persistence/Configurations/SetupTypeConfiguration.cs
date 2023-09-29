using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class SetupTypeConfiguration : IEntityTypeConfiguration<SetupType>
    {
        public void Configure(EntityTypeBuilder<SetupType> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);                     
            builder.Property(x => x.ModifiedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedBy).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
        }
    }
}
