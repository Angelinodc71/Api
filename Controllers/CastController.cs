using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        
        [HttpGet("{id}", Name = "getCast")]
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

        [HttpPost]
        public IActionResult CreateCast(int movieId, [FromBody] CastForCreationDto castForCreationDto) 
        {
            /* Estas validaciones no deberían de hacerse ni en el Controller ni en el Model, sino en una clase aparte
            /* Hay una alternativa llamada FLUENT VALIDATION, una libreria de .NET
            /* if (castForCreationDto.name == castForCreationDto.character) 
            {
                ModelState.AddModelError(
                    "Name",
                    "El nombre debe de ser distinto al personaje"
                );
                return BadRequest(ModelState);
            }*/

            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.id == movieId);
            
            if (movie == null) 
            {
                return NotFound();
            }

            var maxCastId = MoviesDataStore.Current.Movies.SelectMany(x => x.Casts).Max(f => f.id);    

            var newCast = new CastDto
            {
                id = ++maxCastId,
                name = castForCreationDto.name,
                character = castForCreationDto.character
            };

            movie.Casts.Add(newCast);

            return CreatedAtRoute 
            (
                nameof(getCast),
                new { movieId, id = newCast.id},
                castForCreationDto    
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCast(int movieId, int id, [FromBody] CastForUpdateDto castForUpdate)
        {
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.id == movieId);
            
            if (movie == null) 
            {
                return NotFound();
            }
            
            var castFromStore = movie.Casts.FirstOrDefault(x => x.id == id);

            if (castFromStore == null) 
            {
                return NotFound();
            }

            castFromStore.name = castForUpdate.name;
            castFromStore.character = castForUpdate.character;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateCast (int movieId, int id, [FromBody] 
        JsonPatchDocument<CastForUpdateDto> patchDocument)
        {
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.id == movieId);
            
            if (movie == null) 
            {
                return NotFound();
            }
            
            var castFromStore = movie.Casts.FirstOrDefault(x => x.id == id);

            if (castFromStore == null) 
            {
                return NotFound();
            }

            var castToPatch = new CastForUpdateDto() 
            {
                name = castFromStore.name,
                character = castFromStore.character
            };
            
            patchDocument.ApplyTo(castToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(castToPatch))
            {
                return BadRequest(ModelState);
            }

            castFromStore.name = castToPatch.name;
            castFromStore.character = castToPatch.character;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCast (int movieId, int id) 
        {
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.id == movieId);
            
            if (movie == null) 
            {
                return NotFound();
            }
            
            var castFromStore = movie.Casts.FirstOrDefault(x => x.id == id);

            if (castFromStore == null) 
            {
                return NotFound();
            }

            movie.Casts.Remove(castFromStore);

            return NotFound();        
        }
    }
}