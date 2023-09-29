using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PlanName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SubscriptionTypeId).IsRequired();
            builder.Property(x => x.ValidityPeriod).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.Amout).IsRequired();
            builder.Property(x => x.NoOfUse).IsRequired();
            builder.Property(x => x.IsActive);
        }

    }
}
