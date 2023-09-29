using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.DocumentTypeCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.DocumentTypeName).IsRequired().HasMaxLength(200); 
            builder.Property(x => x.DocumentTag).HasMaxLength(20);
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
