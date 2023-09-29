using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class ApprovalRoleConfiguration : IEntityTypeConfiguration<OrganisationApprovalRole>
    {
        public void Configure(EntityTypeBuilder<OrganisationApprovalRole> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.IsInternalUse).IsRequired();
            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(75);
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
