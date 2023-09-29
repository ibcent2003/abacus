using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ProcessRequiredDocumentConfiguration : IEntityTypeConfiguration<ProcessRequiredDocument>
    {
        public void Configure(EntityTypeBuilder<ProcessRequiredDocument> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProcessId).IsRequired();
            builder.Property(x => x.RequiredDocumentId).IsRequired();
            builder.Property(x => x.ProcessCode).IsRequired().HasMaxLength(6);
            builder.Property(x => x.Mandatory).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
