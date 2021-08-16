using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private IMovieInfoRepository _repository;

        public MoviesController (IMovieInfoRepository repository) 
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public IActionResult GetMovies(){
            // return Ok(MoviesDataStore.Current.Movies);
            
            var movies = _repository.GetMovies();

            var results = new List<MovieDto>();

            foreach (var movieEntity in movies) 
            {
                results.Add(
                    new MovieDto
                    {
                        id = movieEntity.id,
                        name = movieEntity.name,
                        description = movieEntity.description
                    }
                );
            }
            
            return Ok(results);

        }
        
        [HttpGet("{id}")]
        public IActionResult getMovie (int id, bool includeCast)
        {
            var movie = _repository.GetMovie(id, includeCast);

            if (movie == null) 
            {
                return NotFound();
            }

            var result = new MovieDto
            {
                id = movie.id,
                name = movie.name,
                description = movie.description
            };

            foreach (var cast in movie.Casts)
            {
                result.Casts.Add(
                    new CastDto
                    {
                        id = cast.id,
                        name = cast.name,
                        character = cast.character
                    }
                );
            }
        
            return Ok(result);
        }
    }
}