using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ActorService _actorService;
        private readonly ILogger<ActorController> _logger;

        public ActorController(ActorService actorService, ILogger<ActorController> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<ActorDto>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todos los actores.");
                return _actorService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los actores.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de actores.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ActorDto> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando el actor con ID: {id}");
                var actor = _actorService.Get(id);

                if (actor == null)
                {
                    _logger.LogWarning($"Actor con ID: {id} no encontrado.");
                    return NotFound();
                }

                return actor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el actor con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener el actor.");
            }
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            try
            {
                _logger.LogInformation($"Creando nuevo actor: {actor.Nombre}");
                _actorService.Add(actor);
                return CreatedAtAction(nameof(Get), new { id = actor.ActorId }, actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear el actor.");
                return StatusCode(500, "Un error ocurrió al crear el actor.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Actor actor)
        {
            try
            {
                _logger.LogInformation($"Actualizando actor con ID: {id}");
                if (id != actor.ActorId)
                {
                    _logger.LogWarning($"No se puede actualizar: Actor con ID: {id} no encontrada.");
                    return NotFound();
                }

                var existingActor = _actorService.Get(id);
                if (existingActor is null)
                {
                    _logger.LogWarning($"No se puede actualizar: Actor con ID: {id} no encontrada.");
                    return NotFound();
                }

                _actorService.Update(actor);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar el actor con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar el actor.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando actor con ID: {id}");
                var actor = _actorService.Get(id);

                if (actor is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Actor con ID: {id} no encontrada.");
                    return NotFound();
                }

                _actorService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar el actor con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar el actor.");
            }
        }
    }
}