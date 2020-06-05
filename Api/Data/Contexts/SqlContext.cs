using Api.Data.Configurations;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        { }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<Brewery> Breweries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BreweryConfiguration());
            builder.ApplyConfiguration(new BeerConfiguration());
        }
    }
}
