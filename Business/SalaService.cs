using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business;

public class SalaService
{
    private readonly ISalaRepository _salaRepository;
    private readonly ILogger<SalaService> _logger;

    public SalaService(ISalaRepository salaRepository, ILogger<SalaService> logger)
    {
        _salaRepository = salaRepository;
        _logger = logger;
    }

    public List<Sala> GetAll()
    {
        _logger.LogInformation("Obteniendo todas las salas.");
        try
        {
            var salas = _salaRepository.GetAll();
            _logger.LogInformation($"Retornadas {salas.Count} salas.");
            return salas;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las salas.");
            throw;
        }
    }

    public Sala? Get(int id)
    {
        _logger.LogInformation($"Buscando sala con ID: {id}");
        try
        {
            _logger.LogInformation($"Sala con ID: {id} encontrada.");
            return _salaRepository.Get(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener la sala con ID: {id}.");
            throw;
        }
    }

    public void Add(Sala sala)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar una nueva sala: {JsonSerializer.Serialize(sala)}");
            _salaRepository.Add(sala);
            _logger.LogInformation($"Sala agregada con éxito.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar una nueva sala");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation($"Intentando eliminar la sala con ID: {id}");
            _salaRepository.Delete(id);
            _logger.LogInformation($"Sala con ID: {id} eliminada correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar la sala con ID: {id}");
            throw;
        }
    }

    public void Update(Sala sala, int id)
    {
        try
        {
            _logger.LogInformation($"Intentando actualizar la sala con ID: {id}");
            _salaRepository.Update(sala, id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar la sala con ID: {id}");
            throw;
        }
    }
}