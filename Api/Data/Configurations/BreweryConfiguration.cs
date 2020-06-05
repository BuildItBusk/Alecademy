using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations
{
    public class BreweryConfiguration : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(b => b.CountryCode).HasMaxLength(2).IsRequired(true);
            builder.HasIndex(b => b.CountryCode).IsUnique(false);
        }
    }
}
