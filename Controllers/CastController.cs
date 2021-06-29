using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId}/casts")]
    public class CastController : ControllerBase
    {
        [HttpGet]
        public IActionResult getCasts (int movieId) 
        {
            var movie = MoviesDataStore.Current
            .Movies.FirstOrDefault(x => x.id == movieId);

            if (movie==null) {
                return NotFound();
            }

            return Ok(movie.Casts);
        }
        
        [HttpGet("{id}")]
        public IActionResult getCast(int movieId, int id) 
        {
            var movie = MoviesDataStore.Current
            .Movies.FirstOrDefault(x => x.id == movieId);

            if (movie == null) 
            {
                return NotFound();
            }

            var cast = movie.Casts.FirstOrDefault(x => x.id == id); 
            
            if (cast == null) 
            {
                return NotFound();
            }

            return Ok(cast);
        }
    }
}