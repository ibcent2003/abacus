using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{

    //Also has chapterr
    public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.SectorId).IsRequired();

            
    }
    }
}
