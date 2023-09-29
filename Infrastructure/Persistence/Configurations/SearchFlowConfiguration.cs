using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class SearchFlowConfiguration : IEntityTypeConfiguration<SearchFlow>
    {
        public void Configure(EntityTypeBuilder<SearchFlow> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(x => x.HeaderId).IsRequired();
            builder.Property(x => x.Flow).IsRequired();
            builder.Property(x => x.HeadingId).IsRequired();           
        }
    }
}
