using System;
using System.Collections.Generic;
using System.Linq;
using Api.Entities;
using Api.Context;
using Microsoft.EntityFrameworkCore;
using Api.Services;

namespace api.Services
{
  public class MovieInfoRepository : IMovieInfoRepository
  {
    private MovieInfoContext _context;

    public MovieInfoRepository(MovieInfoContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Cast GetCastByMovie(int movieId, int castId)
    {
      return _context.Casts
           .Where(x => x.movieId == movieId && x.id == castId).FirstOrDefault();
    }

    public IEnumerable<Cast> GetCastsByMovie(int movieId)
    {
      return _context.Casts
          .Where(x => x.movieId == movieId).ToList();
    }

    public Movie GetMovie(int movieId, bool includeCast)
    {
      if (includeCast)
      {
        return _context.Movies.Include(c => c.Casts)
                .Where(x => x.id == movieId).FirstOrDefault();
      }

      return _context.Movies
                    .Where(x => x.id == movieId).FirstOrDefault();

    }
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.name).ToList();
        }

        public bool MovieExists(int movieId) => _context.Movies.Any(x => x.id == movieId);
    }
}