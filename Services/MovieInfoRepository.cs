using System;
using System.Collections.Generic;
using Api.Context;
using Api.Entities;

namespace Api.Services
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cast> GetCastsByMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public Movie GetMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            throw new System.NotImplementedException();
        }
    }
}