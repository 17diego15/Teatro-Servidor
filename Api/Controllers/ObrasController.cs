using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObrasController : ControllerBase
    {
        private readonly ObraService _obraService;
        private readonly ILogger<ObrasController> _logger;

        public ObrasController(ObraService obraService, ILogger<ObrasController> logger)
        {
            _obraService = obraService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<ObraDto>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todas las obras.");
                return _obraService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las obras.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de obras.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ObraDto> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando obra con ID: {id}");
                var obra = _obraService.Get(id);

                if (obra == null)
                {
                    _logger.LogWarning($"Obra con ID: {id} no encontrada.");
                    return NotFound();
                }

                return obra;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo la obra con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener la obra.");
            }
        }

        [HttpPost]
        public IActionResult Create(ObraDto obrasDto)
        {
            try
            {
                _logger.LogInformation($"Creando nueva obra con título: {obrasDto.Titulo}");
                var obraId = _obraService.Add(obrasDto);
                return CreatedAtAction(nameof(Get), new { id = obraId }, obrasDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear la obra.");
                return StatusCode(400, "Un error ocurrió al crear la obra.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ObraDto obra)
        {
            try
            {
                _logger.LogInformation($"Actualizando obra con ID: {id}");
                var existingObra = _obraService.Get(id);
                if (existingObra == null)
                {
                    _logger.LogWarning($"No se puede actualizar: Obra con ID: {id} no encontrada.");
                    return NotFound();
                }

                _obraService.Update(obra, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar la obra con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar la obra.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando obra con ID: {id}");
                var obra = _obraService.Get(id);

                if (obra is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Obra con ID: {id} no encontrada.");
                    return NotFound();
                }

                _obraService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar la obra con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar la obra.");
            }
        }
    }
}