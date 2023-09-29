using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.State).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StateName).HasMaxLength(100);
            builder.HasIndex(x => x.WorkflowProcessId).IsUnique();
            builder.Property(x => x.AuthorId).IsRequired().HasMaxLength(40);
        }
    }
}
