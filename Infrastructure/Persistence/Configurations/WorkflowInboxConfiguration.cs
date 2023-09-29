using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class WorkflowInboxConfiguration : IEntityTypeConfiguration<WorkflowInbox>
    {
        public void Configure(EntityTypeBuilder<WorkflowInbox> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProcessId).IsRequired();
            builder.Property(x => x.IdentityId).IsRequired().HasMaxLength(256);
        }
    }
}
