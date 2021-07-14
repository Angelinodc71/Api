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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().
                HasData(
                    new Movie()
                    {
                        id = 1,
                        name = "Pandillas de nueva york",
                        description = "Gangs of New York ye una película histórica del añu 2002 dirixida por Martin Scorsese"
                    },
                    new Movie()
                    {
                        id = 2,
                        name = "Forrest Gump",
                        description = "Es un chico que sufre un cierto retraso mental. A pesar de todo, gracias a su tenacidad y a su buen corazón será protagonista de acontecimientos cruciales de su país"
                    },
                    new Movie()
                    {
                        id = 3,
                        name = "Taxi Driver",
                        description = "Ambientada en la Nueva York de la década de 1970, poco después de que terminara la guerra de Vietnam, se centra en la vida de Travis Bickle, un excombatiente solitario e inestable que debido a su insomnio crónico comienza a trabajar como taxista,"
                    }
                );

            modelBuilder.Entity<Cast>()
                .HasData(
                    new Cast()
                    {
                        id = 1,
                        name = "Daniel Day-Lewis",
                        character = "The Butcher",
                        movieId = 1
                    },
                    new Cast()
                    {
                        id = 2,
                        name = "Leonardo DiCaprio",
                        character = "Amsterdam Vallon",
                        movieId = 1
                    },
                    new Cast()
                    {
                        id = 3,
                        name = "Liam Neeson",
                        character = "Priest Vallon",
                        movieId = 1
                    },
                    new Cast()
                    {
                        id = 4,
                        name = "Tom Hanks",
                        character = "Forrest Gump",
                        movieId = 2
                    },
                    new Cast()
                    {
                        id = 5,
                        name = "Gary Sinise",
                        character = "Teniente Dan",
                        movieId = 2
                    },
                    new Cast()
                    {
                        id = 6,
                        name = "Robin Wright",
                        character = "Jenny curran",
                        movieId = 2
                    },
                    new Cast()
                    {
                        id = 7,
                        name = "Robert De Niro",
                        character = "Travis Bickle",
                        movieId = 3
                    },
                    new Cast()
                    {
                        id = 8,
                        name = "Martin scorsese",
                        character = "Passenger",
                        movieId = 3
                    },
                    new Cast()
                    {
                        id = 9,
                        name = "Jodie Foster",
                        character = "Iris",
                        movieId = 3
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}