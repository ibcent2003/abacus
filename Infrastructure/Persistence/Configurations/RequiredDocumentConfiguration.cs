using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class RequiredDocumentConfiguration : IEntityTypeConfiguration<RequiredDocument>
    {
        public void Configure(EntityTypeBuilder<RequiredDocument> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.DocumentName).IsRequired().HasMaxLength(125);
            builder.Property(x => x.DocumentDescription).IsRequired().HasMaxLength(250);
            builder.Property(x => x.DocumentFormatString).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.MaximumSize).IsRequired();
        }
    }
}
