using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ProcessSubmittedDocumentConfiguration : IEntityTypeConfiguration<ProcessSubmittedDocument>
    {
        public void Configure(EntityTypeBuilder<ProcessSubmittedDocument> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.DocumentExtension).IsRequired().HasMaxLength(20);
            builder.Property(x => x.DocumentOwnerId).IsRequired();
            builder.Property(x => x.ProcessRequiredDocumentId).IsRequired();
            builder.Property(x => x.DocumentUrl).IsRequired().HasMaxLength(45);
            builder.Property(x => x.DocumentName).IsRequired().HasMaxLength(125);
        }
    }
}
