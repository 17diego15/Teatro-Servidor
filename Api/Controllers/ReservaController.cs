using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        private readonly ILogger<FuncionController> _logger;

        public ReservaController(ReservaService reservaService, ILogger<FuncionController> logger)
        {
            _reservaService = reservaService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<ReservaDto>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todas las reservas.");
                return _reservaService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las reservas.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de reservas.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Reserva> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando reserva con ID: {id}");
                var reserva = _reservaService.Get(id);

                if (reserva == null)
                {
                    _logger.LogWarning($"Reserva con ID: {id} no encontrada.");
                    return NotFound();
                }

                return reserva;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo la reserva con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener la reserva.");
            }
        }

        [HttpGet("/funcion/{id}/reservas")]
        public ActionResult<List<ReservaDto>> GetFuncion(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando funcion con ID: {id}");
                var funcion = _reservaService.GetFuncion(id);

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
        public IActionResult Create(List<ReservaDto> reservasDto)
        {
            try
            {
                _logger.LogInformation($"{reservasDto.Count} reservas creadas");
                var reservasIds = _reservaService.Add(reservasDto);
                return Created("", reservasIds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear la reserva.");
                return StatusCode(500, "Un error ocurrió al crear la reserva.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Reserva reserva)
        {
            try
            {
                _logger.LogInformation($"Actualizando reserva con ID: {id}");
                var existingReserva = _reservaService.Get(id);
                if (existingReserva == null)
                {
                    _logger.LogWarning($"No se puede actualizar: Reserva con ID: {id} no encontrada.");
                    return NotFound();
                }

                _reservaService.Update(reserva, id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar la reserva con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar la reserva.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando reserva con ID: {id}");
                var reserva = _reservaService.Get(id);

                if (reserva is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Reserva con ID: {id} no encontrada.");
                    return NotFound();
                }

                _reservaService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar la reserva con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar la reserva.");
            }
        }
    }
}