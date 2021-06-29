using System.Collections.Generic;
using Api.Models;

namespace Api
{
    public class MoviesDataStore
    {
        public static MoviesDataStore Current {get;} = new MoviesDataStore();
        public List<MovieDto> Movies {get;set;}
        public MoviesDataStore () {
            Movies = new List<MovieDto>()
            {
                new MovieDto(){
                    id=1,
                    name="Colegas en el bosque",
                    description="Es una película de animales",
                    Casts = new List<CastDto>() {
                        new CastDto {id=1,name="Geogia Engel",character="Bobbie"},
                        new CastDto {id=2,name="Cody Cameron",character="Mr. Weenie"},
                        new CastDto {id=3,name="Billy Connolly",character="Guido"}
                    }
                },
                new MovieDto(){
                    id=2,
                    name="Piratas del Caribe",
                    description="Es una película de drama/acción ambientada en historias de piratas",
                    Casts = new List<CastDto>() {
                        new CastDto {id=1,name="Johnny Depp",character="Jack Sparrow"},
                        new CastDto {id=2,name="Keira Knightley",character="Elizabeth Swann"},
                        new CastDto {id=3,name="Orlando Bloom",character="Will Turner"}
                    }
                },
                new MovieDto(){
                    id=3,
                    name="Marte",
                    description="Es una película de como sobrevivir en Marte",
                    Casts = new List<CastDto>() {
                        new CastDto {id=1,name="Matt Damon",character="Mark Watney"},
                        new CastDto {id=2,name="Jessica Chastain",character="Melissa Lewis"},
                        new CastDto {id=3,name="Sean Bean",character="Mitch Henderson"}
                    }
                }
            };
        }
    }
}