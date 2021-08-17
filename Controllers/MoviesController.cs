using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private IMovieInfoRepository _repository;
        private IMapper _mapper;

        public MoviesController (IMovieInfoRepository repository, IMapper mapper) 
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
        }
        public IActionResult GetMovies(){
            // return Ok(MoviesDataStore.Current.Movies);
            
            var movies = _repository.GetMovies();
            return Ok(_mapper.Map<IEnumerable<MovieWithoutCastDto>>(movies));

        }
        
        [HttpGet("{id}")]
        public IActionResult getMovie (int id, bool includeCast)
        {
            var movie = _repository.GetMovie(id, includeCast);

            if (movie == null) 
            {
                return NotFound();
            }

            if(!includeCast)
            {
                return Ok(_mapper.Map<MovieWithoutCastDto>(movie));
            }
        
            return Ok(_mapper.Map<MovieDto>(movie));
        }
    }
}