using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class DocumentTransitionHistoryConfiguration : IEntityTypeConfiguration<DocumentTransitionHistory>
    {
        public void Configure(EntityTypeBuilder<DocumentTransitionHistory> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Command).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Order).IsRequired();
            builder.Property(x => x.DestinationState).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.InitialState).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Comment).HasMaxLength(400);
        }
    }
}
