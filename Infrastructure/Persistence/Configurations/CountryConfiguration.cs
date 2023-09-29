using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.CountryName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CountryCode).HasMaxLength(20);
            builder.Property(x => x.CurrencyCode).HasMaxLength(10);
            builder.Property(x => x.CurrencyName).HasMaxLength(50);         
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
