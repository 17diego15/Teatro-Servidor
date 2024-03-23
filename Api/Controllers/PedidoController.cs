using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(PedidoService pedidoService, ILogger<PedidoController> logger)
        {
            _pedidoService = pedidoService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<PedidoDto>> GetAll(int usuarioID = 0)
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todos los pedidos.");
                return _pedidoService.GetAll(usuarioID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todos los pedidos.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de pedidos.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PedidoDto> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando pedido con ID: {id}");
                var pedido = _pedidoService.Get(id);

                if (pedido == null)
                {
                    _logger.LogWarning($"Pedido con ID: {id} no encontrada.");
                    return NotFound();
                }

                return pedido;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el pedido con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener el pedido.");
            }
        }

        [HttpPost]
        public IActionResult Create(PedidoDto pedidoDto)
        {
            try
            {
                _logger.LogInformation($"Creando nuevo pedido con id: {pedidoDto.PedidoID}");
                var pedidoId = _pedidoService.Add(pedidoDto);

                return CreatedAtAction(nameof(Get), new { id = pedidoId }, pedidoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear el pedido.");
                return StatusCode(500, "Un error ocurrió al crear el pedido.");
            }
        }
    }
}