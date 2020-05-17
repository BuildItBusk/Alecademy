using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations
{
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(b => b.ImageUri).HasMaxLength(4000).IsRequired(false);
            builder.Property(b => b.AlcoholVol).HasColumnType("decimal(5,2)").IsRequired(true);

            builder.HasIndex(b => b.Name).IsUnique(true);
            builder.HasIndex(b => b.OriginId).IsUnique(false);
        }
    }
}
