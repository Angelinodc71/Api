using System.Collections.Generic;
using System.Linq;
using Api.Entities;

namespace Api.Services
{
    public interface IMovieInfoRepository
    {
         IEnumerable<Movie> GetMovies();

         Movie GetMovie(int movieId, bool includeCast);

         IEnumerable<Cast> GetCastsByMovie(int movieId);

         Cast GetCastByMovie(int movieId, int castId);

         bool MovieExists(int movieId);

         void AddCastForMovie(int movieId, Cast cast);

         bool Save();

        void UpdateCastForMovie(int movieId, Cast cast);

        void DeleteCast(Cast cast);
    }
}