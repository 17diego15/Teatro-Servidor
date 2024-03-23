using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business;

public class PedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly ILogger<PedidoService> _logger;


    public PedidoService(IPedidoRepository pedidoRepository, ILogger<PedidoService> logger)
    {
        _pedidoRepository = pedidoRepository;
        _logger = logger;
    }

    public List<PedidoDto> GetAll(int usuarioID = 0)
    {
        _logger.LogInformation("Obteniendo todos los pedidos.");
        try
        {
            var pedido = _pedidoRepository.GetAll(usuarioID);

            var pedidoDto = pedido.Select(p => new PedidoDto
            {
                PedidoID = p.PedidoID,
                UsuarioID = p.UsuarioID,
                FuncionID = p.FuncionID,
                Precio = p.Precio,
                PrecioTotal = p.PrecioTotal,
                Fecha = p.Fecha,
                NumeroDeReservas = p.NumeroDeReservas ?? 0,
            }).ToList();
            _logger.LogInformation($"Retornadas {pedido.Count} pedidos.");
            return pedidoDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas los pedidos.");
            throw;
        }
    }

    public PedidoDto? Get(int id)
    {
        _logger.LogInformation($"Buscando pedido con ID: {id}");
        try
        {
            var pedido = _pedidoRepository.Get(id);
            if (pedido == null)
            {
                _logger.LogWarning($"Pedido con ID: {id} no encontrada.");
                return null;
            }

            var pedidoDto = new PedidoDto
            {
                PedidoID = pedido.PedidoID,
                UsuarioID = pedido.UsuarioID,
                FuncionID = pedido.FuncionID,
                Precio = pedido.Precio,
                PrecioTotal = pedido.PrecioTotal,
                Fecha = pedido.Fecha,
                NumeroDeReservas = pedido.NumeroDeReservas ?? 0,
            };
            _logger.LogInformation($"Pedido con ID: {id} encontrada.");
            return pedidoDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener el pedido con ID: {id}.");
            throw;
        }
    }

    public int Add(PedidoDto pedidoDto)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar un nuevo pedido: {JsonSerializer.Serialize(pedidoDto)}");
            var pedido = new Pedido
            {
                PedidoID = pedidoDto.PedidoID,
                UsuarioID = pedidoDto.UsuarioID,
                FuncionID = pedidoDto.FuncionID,
                Precio = pedidoDto.Precio,
                PrecioTotal = pedidoDto.PrecioTotal,
                Fecha = pedidoDto.Fecha,
                NumeroDeReservas = pedidoDto.NumeroDeReservas,
            };
            _pedidoRepository.Add(pedido);
            _logger.LogInformation($"Pedido agregado con éxito con ID {pedido.PedidoID}");
            return pedido.PedidoID;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar una nueva funcion");
            throw;
        }
    }
}
