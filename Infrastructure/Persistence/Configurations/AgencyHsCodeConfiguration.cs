using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class AgencyHsCodeConfiguration : IEntityTypeConfiguration<AgencyHsCode>
    {
        public void Configure(EntityTypeBuilder<AgencyHsCode> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.AgencyId).IsRequired();
            builder.Property(x => x.HsCodePoolId).IsRequired();
            builder.Property(x => x.DocumentTypeId).IsRequired();
            builder.Property(x => x.Code);
        }
    }
}
