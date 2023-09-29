using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class SubscriberProcessWorkflowConfiguration : IEntityTypeConfiguration<SubscriberProcessWorkflow>
    {
        public void Configure(EntityTypeBuilder<SubscriberProcessWorkflow> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProcessId).IsRequired();
        }
    }
}
