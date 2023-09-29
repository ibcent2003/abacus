using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class UserApprovalRoleConfiguration : IEntityTypeConfiguration<OrganisationUserApprovalRole>
    {
        public void Configure(EntityTypeBuilder<OrganisationUserApprovalRole> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            // builder.Property(x => x.OrganisationApprovalRole).IsRequired();
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(40);
            builder.Property(x => x.IsInternalUse).IsRequired();
        }
    }
}
