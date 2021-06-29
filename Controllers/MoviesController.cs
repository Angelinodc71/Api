using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        public JsonResult getMovies(){
            return new JsonResult(MoviesDataStore.Current.Movies);
        }
        [HttpGet("{id}")]
        public IActionResult getMovie (int id)
        {
            var movie = MoviesDataStore.Current
            .Movies.FirstOrDefault(x => x.id == id);

            if (movie == null) 
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}