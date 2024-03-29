using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;


namespace Business;

public class ReservaService
{
    private readonly IReservaRepository _reservaRepository;
    private readonly ILogger<ReservaService> _logger;

    public ReservaService(IReservaRepository reservaRepository, ILogger<ReservaService> logger)
    {
        _reservaRepository = reservaRepository;
        _logger = logger;
    }

    public List<ReservaDto> GetAll(int funcionID = 0)
    {
        _logger.LogInformation("Obteniendo todas las reservas.");
        try
        {
            var reserva = _reservaRepository.GetAll(funcionID);

            var reservaDto = reserva.Select(r => new ReservaDto
            {
                ReservaID = r.ReservaID,
                FuncionID = r.FunciónID ?? 0,
                NumeroFila = r.NumeroFila ?? 0,
                NumeroColumna = r.NumeroColumna ?? 0,
                UsuarioID = r.UsuarioID ?? 0,
                PedidoID = r.PedidoID ?? 0,
            }).ToList();
            _logger.LogInformation($"Retornadas {reserva.Count} reservas.");
            return reservaDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las reservas.");
            throw;
        }
    }

    public Reserva? Get(int id)
    {
        _logger.LogInformation($"Buscando reserva con ID: {id}");
        try
        {
            _logger.LogInformation($"Reserva con ID: {id} encontrada.");
            return _reservaRepository.Get(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener la reserva con ID: {id}.");
            throw;
        }
    }

    public List<int> Add(List<ReservaDto> reservasDto)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar una nueva reserva: {JsonSerializer.Serialize(reservasDto)}");
            var reservas = reservasDto.Select(reservaDto => new Reserva
            {
                ReservaID = reservaDto.ReservaID,
                FunciónID = reservaDto.FuncionID,
                NumeroFila = reservaDto.NumeroFila,
                NumeroColumna = reservaDto.NumeroColumna,
                UsuarioID = reservaDto.UsuarioID,
                PedidoID = reservaDto.PedidoID,
            }).ToList();
            _reservaRepository.Add(reservas);
            _logger.LogInformation($"Reserva agregada con éxito.");
            return reservas.Select(r => r.ReservaID).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar una nueva reserva");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation($"Intentando eliminar la reserva con ID: {id}");
            _reservaRepository.Delete(id);
            _logger.LogInformation($"Reserva con ID: {id} eliminada correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar la reserva con ID: {id}");
            throw;
        }
    }

    public void Update(Reserva reserva, int id)
    {
        try
        {
            _logger.LogInformation($"Intentando actualizar la reserva con ID: {id}");
            _reservaRepository.Update(reserva, id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar la reserva con ID: {id}");
            throw;
        }
    }
}