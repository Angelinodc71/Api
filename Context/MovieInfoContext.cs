using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class MovieInfoContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("co");
            base.OnConfiguring(optionsBuilder);
        }
    }
}