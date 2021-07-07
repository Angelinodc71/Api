using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class MovieInfoContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }

        public MovieInfoContext(DbContextOptions<MovieInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}