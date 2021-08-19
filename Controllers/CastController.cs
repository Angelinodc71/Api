using System;
using System.Collections.Generic;
using System.Linq;
using Api.Entities;
using Api.Models;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId}/casts")]
    public class CastController : ControllerBase
    {
        private ILogger<CastController> _logger;
        private IMailService _localMailService;
        private IMovieInfoRepository _repository;
        private IMapper _mapper;

        public CastController (ILogger<CastController> logger, IMailService localMailService, IMovieInfoRepository repository,
        IMapper mapper) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _localMailService = localMailService ?? throw new ArgumentNullException(nameof(localMailService));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult getCasts (int movieId) 
        {
            // var movie = MoviesDataStore.Current
            // .Movies.FirstOrDefault(x => x.id == movieId);

            if (!_repository.MovieExists(movieId)) {
                return NotFound();
            }

            var casts = _repository.GetCastsByMovie(movieId);

            return Ok(_mapper.Map<IEnumerable<CastDto>>(casts));
        }
        
        [HttpGet("{id}", Name = "getCast")]
        public IActionResult getCast(int movieId, int id) 
        {
            try {
                // var movie = MoviesDataStore.Current
                // .Movies.FirstOrDefault(x => x.id == movieId);

                if (!_repository.MovieExists(movieId)) 
                {
                    return NotFound();
                }

                var cast = _repository.GetCastByMovie(movieId, id); 
                
                if (cast == null) 
                {
                    _logger.LogInformation($"This cast with id {id} not found !");
                    return NotFound();
                }

                return Ok(_mapper.Map<CastDto>(cast));
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"This cast with id {id} not found (user)!", ex);
                return StatusCode(500,"Error 500, recurso no encontrado");
            }
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

            
            if (!_repository.MovieExists(movieId)) 
            {
                return NotFound();
            }

            var finalCast = _mapper.Map<Cast>(castForCreationDto);
            _repository.AddCastForMovie(movieId, finalCast);
            _repository.Save();

            var createdCastToReturn = _mapper.Map<CastForCreationDto>(finalCast);

            return CreatedAtRoute 
            (
                nameof(getCast),
                new { movieId, id = finalCast.id},
                createdCastToReturn    
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCast(int movieId, int id, [FromBody] CastForUpdateDto castForUpdate)
        {            
            if (!_repository.MovieExists(movieId)) 
            {
                return NotFound();
            }
            
            var castFromStore = _repository.GetCastByMovie(movieId, id);

            if (castFromStore == null) 
            {
                return NotFound();
            }

            _mapper.Map(castForUpdate, castFromStore);
            _repository.UpdateCastForMovie(movieId, castFromStore);
            _repository.Save();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateCast (int movieId, int id, [FromBody] 
        JsonPatchDocument<CastForUpdateDto> patchDocument)
        {
            
            if (!_repository.MovieExists(movieId)) 
            {
                return NotFound();
            }
            
            var castFromStore = _repository.GetCastByMovie(movieId, id);

            if (castFromStore == null) 
            {
                return NotFound();
            }

            var castToPatch = _mapper.Map<CastForUpdateDto>(castFromStore);
            
            patchDocument.ApplyTo(castToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(castToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(castToPatch, castFromStore);
            _repository.UpdateCastForMovie(movieId, castFromStore);
            _repository.Save();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCast (int movieId, int id) 
        {
            
            if (!_repository.MovieExists(movieId)) 
            {
                return NotFound();
            }
            
            var castFromStore = _repository.GetCastByMovie(movieId, id);

            if (castFromStore == null) 
            {
                return NotFound();
            }

            _localMailService.Send("Recurso eliminado", $"El recurso con id {id} fue eliminado");

            _repository.DeleteCast(castFromStore);
            _repository.Save();

            return NoContent();        
        }
    }
}