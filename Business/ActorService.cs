using Models;
using Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business;

public class ActorService
{
    private readonly IActorRepository _actorRepository;
    private readonly ILogger<ActorService> _logger;

    public ActorService(IActorRepository actorRepository, ILogger<ActorService> logger)
    {
        _actorRepository = actorRepository;
        _logger = logger;
    }

    public List<ActorDto> GetAll()
    {
        _logger.LogInformation("Obteniendo todas los actores.");
        try
        {
            var actor = _actorRepository.GetAll();

            var actorDto = actor.Select(o => new ActorDto
            {
                ActorId = o.ActorId,
                Nombre = o.Nombre
            }).ToList();
            _logger.LogInformation($"Retornados {actor.Count} actores.");
            return actorDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas los actores.");
            throw;
        }
    }

    public ActorDto? Get(int id)
    {
        _logger.LogInformation($"Buscando actor con ID: {id}");
        try
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
            {
                _logger.LogWarning($"Actor con ID: {id} no encontrado.");
                return null;
            }

            var actorDto = new ActorDto
            {
                ActorId = actor.ActorId,
                Nombre = actor.Nombre
            };
            _logger.LogInformation($"Actor con ID: {id} encontrado.");
            return actorDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener el actor con ID: {id}.");
            throw;
        }

    }

    public void Add(Actor actor)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar un nueva actor: {JsonSerializer.Serialize(actor)}");
            _actorRepository.Add(actor);
            _logger.LogInformation($"Actor agregado con éxito con ID {actor.ActorId}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar un nuevo actor");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation($"Intentando eliminar el actor con ID: {id}");
            _actorRepository.Delete(id);
            _logger.LogInformation($"Actor con ID: {id} eliminado correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar la funcion con ID: {id}");
            throw;
        }
    }

    public void Update(Actor actor)
    {
        try
        {
            _logger.LogInformation($"Intentando actualizar el actor con ID: {actor.ActorId}");
            _actorRepository.Update(actor);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar la funcion con ID: {actor.ActorId}");
            throw;
        }
    }
}
