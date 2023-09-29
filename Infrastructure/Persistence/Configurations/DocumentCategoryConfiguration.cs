using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class DocumentCategoryConfiguration : IEntityTypeConfiguration<DocumentCategory>
    {
        public void Configure(EntityTypeBuilder<DocumentCategory> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
         //  builder.Property(x => x.DocumentTypeId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
