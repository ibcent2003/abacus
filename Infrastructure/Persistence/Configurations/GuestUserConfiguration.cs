using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
   public  class GuestUserConfiguration : IEntityTypeConfiguration<GuestUser>
    {
        public void Configure(EntityTypeBuilder<GuestUser> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Ip).IsRequired();
            builder.Property(x => x.NoOfUse).IsRequired();
            builder.Property(x => x.AccessDate).IsRequired();         
        }
    }
}
