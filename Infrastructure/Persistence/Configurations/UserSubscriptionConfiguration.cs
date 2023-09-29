using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(450);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.SubscriberId).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.MiddleName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.EmailAddress).HasMaxLength(256);
        }
    }
}
