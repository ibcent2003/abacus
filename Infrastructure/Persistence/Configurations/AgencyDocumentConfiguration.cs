using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class AgencyDocumentConfiguration : IEntityTypeConfiguration<AgencyDocument>
    {
        public void Configure(EntityTypeBuilder<AgencyDocument> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.AgencyId).IsRequired();
            builder.Property(x => x.DocumentTypeId).IsRequired();
            builder.Property(x => x.HSCodePoolId).IsRequired();
          

        }
    }
}
