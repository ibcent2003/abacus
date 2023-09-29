using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class HeaderConfiguration : IEntityTypeConfiguration<Header>
    {
        public void Configure(EntityTypeBuilder<Header> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.ModifiedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedBy).IsRequired();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.IsUsedInSearchFlow);
        }
    }
}
