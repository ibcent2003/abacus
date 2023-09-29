using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ProcessConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProcessName).IsRequired().HasMaxLength(125);
            builder.Property(x => x.ProcessDescription).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ProcessCode).IsRequired().HasMaxLength(6);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsInternal).IsRequired().HasDefaultValue(false);

        }
    }
}
