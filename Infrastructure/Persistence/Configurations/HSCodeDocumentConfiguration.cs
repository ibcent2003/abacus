using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class HSCodeDocumentConfiguration : IEntityTypeConfiguration<HSCodeDocument>
    {
        public void Configure(EntityTypeBuilder<HSCodeDocument> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HsCodePoolId).IsRequired();     
            builder.Property(x => x.DocumentCategoryId).IsRequired();
            builder.Property(x => x.Docs).IsRequired();
        }
    }
}
