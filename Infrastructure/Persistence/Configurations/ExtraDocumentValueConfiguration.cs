using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ExtraDocumentValueConfiguration : IEntityTypeConfiguration<ExtraDocumentValue>
    {
        public void Configure(EntityTypeBuilder<ExtraDocumentValue> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.DocumentTypeId).IsRequired();
            builder.Property(x => x.ExtraName).IsRequired();
            builder.Property(x => x.ExtraValue).IsRequired();
            builder.Property(x => x.AgencyHsCodeId).IsRequired();

        }
    }
}
