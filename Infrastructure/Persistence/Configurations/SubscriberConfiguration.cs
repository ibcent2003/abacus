using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CountryCode).IsRequired().HasMaxLength(2);
            builder.Property(x => x.City).IsRequired().HasMaxLength(75);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(256);
            builder.Property(x => x.EntityName).IsRequired().HasMaxLength(120);
            builder.Property(x => x.FaxNumber).HasMaxLength(15);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.StreetNumber).IsRequired().HasMaxLength(200);
            builder.Property(x => x.PostCode).IsRequired().HasMaxLength(6);
            builder.Property(x => x.Tin).IsRequired().HasMaxLength(15);
            builder.Property(x => x.ParentId).IsRequired();
            builder.HasIndex(x => x.ParentId).IsUnique();
            builder.Property(x => x.EntityTypeCode).HasMaxLength(4).IsRequired();

        }
    }
}
