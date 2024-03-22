using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionController : ControllerBase
    {
        private readonly FuncionService _funcionService;
        private readonly ILogger<FuncionController> _logger;

        public FuncionController(FuncionService funcionService, ILogger<FuncionController> logger)
        {
            _funcionService = funcionService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<FuncionDto>> GetAll(int obraID = 0)
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todas las funciones.");
                var funciones = _funcionService.GetAll(obraID);

                if (obraID > 0 && !funciones.Any())
                {
                    _logger.LogWarning($"No se encontraron funciones para la obra con ID {obraID}.");
                    return NotFound($"No se encontraron funciones para la obra con ID {obraID}.");
                }

                return funciones;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las funciones.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de funciones.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FuncionDto> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando funcion con ID: {id}");
                var funcion = _funcionService.Get(id);

                if (funcion == null)
                {
                    _logger.LogWarning($"Funcion con ID: {id} no encontrada.");
                    return NotFound();
                }

                return funcion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo la funcion con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener la funcion.");
            }
        }

        [HttpPost]
        public IActionResult Create(FuncionPostDto funcionPostDto)
        {
            try
            {
                _logger.LogInformation($"Creando nueva funcion con obra: {funcionPostDto.ObraID}");
                var funcionId = _funcionService.Add(funcionPostDto);

                return CreatedAtAction(nameof(Get), new { id = funcionId }, funcionPostDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear la funcion.");
                return StatusCode(500, "Un error ocurrió al crear la funcion.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionPostDto funcionPostDto)
        {
            try
            {
                _logger.LogInformation($"Actualizando funcion con ID: {id}");
                if (id != funcionPostDto.FuncionID)
                {
                    _logger.LogWarning($"No se puede actualizar: Funcion con ID: {id} no encontrada.");
                    return BadRequest();

                }

                var existingFuncion = _funcionService.Get(id);
                if (existingFuncion is null)
                {
                    _logger.LogWarning($"No se puede actualizar: Funcion con ID: {id} no encontrada.");
                    return NotFound();
                }

                _funcionService.Update(funcionPostDto, id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar la funcion con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar la funcion.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando funcion con ID: {id}");
                var funcion = _funcionService.Get(id);

                if (funcion is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Funcion con ID: {id} no encontrada.");
                    return NotFound();
                }

                _funcionService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar la funcion con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar la funcion.");
            }
        }

        [HttpGet("/obras/{id}/funcion")]
        public ActionResult GetObras(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando funcion con ID: {id}");
                var funcion = _funcionService.GetObras(id);

                if (funcion != null)
                {
                    return Ok(funcion);
                }
                else
                {
                    _logger.LogWarning($"Funcion con ID: {id} no encontrada.");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al obtener la funcion con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener la funcion.");
            }
        }
    }
}