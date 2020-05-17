using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.HasIndex(c => c.Name).IsUnique(true);

            builder.HasData(
                new Country { Id = 1, Name = "Denmark" },
                new Country { Id = 2, Name = "France" });
        }
    }
}
