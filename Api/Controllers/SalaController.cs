using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _salaService;
        private readonly ILogger<SalaController> _logger;

        public SalaController(SalaService salaService, ILogger<SalaController> logger)
        {
            _salaService = salaService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Sala>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todas las salas.");
                return _salaService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las salas.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de salas.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando sala con ID: {id}");
                var sala = _salaService.Get(id);

                if (sala == null)
                {
                    _logger.LogWarning($"Sala con ID: {id} no encontrada.");
                    return NotFound();
                }

                return sala;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo la sala con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener la sala.");
            }
        }

        [HttpPost]
        public IActionResult Create(Sala sala)
        {
            try
            {
                _logger.LogInformation($"Creando nueva sala con obra: {sala.SalaID}");
                _salaService.Add(sala);
                return CreatedAtAction(nameof(Get), new { id = sala.SalaID }, sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear la sala.");
                return StatusCode(500, "Un error ocurrió al crear la sala.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Sala sala)
        {
            try
            {
                _logger.LogInformation($"Actualizando sala con ID: {id}");
                var existingSala = _salaService.Get(id);
                if (existingSala == null)
                {
                    _logger.LogWarning($"No se puede actualizar: Sala con ID: {id} no encontrada.");
                    return NotFound();
                }
                _salaService.Update(sala, id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar la sala con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar la sala.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando sala con ID: {id}");
                var sala = _salaService.Get(id);

                if (sala is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Sala con ID: {id} no encontrada.");
                    return NotFound();
                }

                _salaService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar la sala con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar la sala.");
            }
        }
    }
}