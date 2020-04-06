using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        { }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
