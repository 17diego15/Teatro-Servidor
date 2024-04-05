using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business;

public class ObraService
{
    private readonly IObraRepository _obraRepository;
    private readonly IActorRepository _actorRepository;
    private readonly ILogger<ObraService> _logger;


    public ObraService(IObraRepository obraRepository, IActorRepository actorRepository, ILogger<ObraService> logger)
    {
        _obraRepository = obraRepository;
        _actorRepository = actorRepository;
        _logger = logger;
    }

    public List<ObraDto> GetAll()
    {
        _logger.LogInformation("Obteniendo todas las obras.");
        try
        {
            var obra = _obraRepository.GetAll();

            var obraDto = obra.Select(o => new ObraDto
            {
                ObraID = o.ObraID,
                Titulo = o.Titulo,
                Director = o.Director,
                Sinopsis = o.Sinopsis,
                Duración = o.Duración,
                Precio = o.Precio,
                Imagen = o.Imagen,
                Actores = o.ObraActores.Select(oa => new ActorDto
                {
                    ActorId = oa.ActorId,
                    Nombre = oa.Actor?.Nombre
                }).ToList()
            }).ToList();
            _logger.LogInformation($"Retornadas {obra.Count} obras.");
            return obraDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las obras.");
            throw;
        }
    }

    public ObraDto? Get(int id)
    {
        _logger.LogInformation($"Buscando obra con ID: {id}");
        try
        {
            var obra = _obraRepository.Get(id);
            if (obra == null)
            {
                _logger.LogWarning($"Obra con ID: {id} no encontrada.");
                return null;
            }

            var obraDto = new ObraDto
            {
                ObraID = obra.ObraID,
                Titulo = obra.Titulo,
                Director = obra.Director,
                Sinopsis = obra.Sinopsis,
                Duración = obra.Duración,
                Precio = obra.Precio,
                Imagen = obra.Imagen,
                Actores = obra.ObraActores.Select(oa => new ActorDto
                {
                    ActorId = oa.ActorId,
                    Nombre = oa.Actor?.Nombre
                }).ToList()
            };
            _logger.LogInformation($"Obra con ID: {id} encontrada.");
            return obraDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener la obra con ID: {id}.");
            throw;
        }
    }


    public int Add(ObraDto obraDto)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar una nueva obra: {JsonSerializer.Serialize(obraDto)}");
            var obraActores = new List<ObraActor>();

            foreach (var actorDto in obraDto.Actores)
            {
                var actorExists = _actorRepository.Get(actorDto.ActorId);
                if (actorExists == null)
                {
                    _logger.LogWarning($"El actor con ID {actorDto.ActorId} no existe en la base de datos.");
                    throw new ArgumentException($"El actor con ID {actorDto.ActorId} no existe en la base de datos.");
                }
                else
                {
                    _logger.LogInformation($"Intentando agregar un nuevo actor: {JsonSerializer.Serialize(actorDto)}");
                    obraActores.Add(new ObraActor { ActorId = actorDto.ActorId });
                }
            }

            var obra = new Obra
            {
                ObraID = obraDto.ObraID,
                Titulo = obraDto.Titulo,
                Director = obraDto.Director,
                Sinopsis = obraDto.Sinopsis,
                Duración = obraDto.Duración,
                Precio = obraDto.Precio,
                Imagen = obraDto.Imagen,
                ObraActores = obraActores
            };
            _obraRepository.Add(obra);
            _logger.LogInformation($"Obra agregada con éxito con ID {obra.ObraID}");
            return obra.ObraID;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar una nueva obra");
            throw;
        }
    }
    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation($"Intentando eliminar la obra con ID: {id}");
            _obraRepository.Delete(id);
            _logger.LogInformation($"Obra con ID: {id} eliminada correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar la obra con ID: {id}");
            throw;
        }
    }

    public void Update(ObraDto obraDto, int id)
    {
        try
        {
            _logger.LogInformation($"Intentando actualizar la obra con ID: {id}");
            var obra = _obraRepository.Get(id);
            if (obra == null)
            {
                _logger.LogWarning($"No se encontró la obra con ID: {id} para actualizar.");
                return;
            }

            obra.Titulo = obraDto.Titulo;
            _logger.LogInformation($"Cambiando Titulo de '{obra.Titulo}' a '{obraDto.Titulo}'.");
            obra.Director = obraDto.Director;
            _logger.LogInformation($"Cambiando Director de '{obra.Director}' a '{obraDto.Director}'.");
            obra.Sinopsis = obraDto.Sinopsis;
            _logger.LogInformation($"Cambiando Sinopsis de '{obra.Sinopsis}' a '{obraDto.Sinopsis}'.");
            obra.Duración = obraDto.Duración;
            _logger.LogInformation($"Cambiando Duración de '{obra.Duración}' a '{obraDto.Duración}'.");
            obra.Precio = obraDto.Precio;
            _logger.LogInformation($"Cambiando Precio de '{obra.Precio}' a '{obraDto.Precio}'.");
            obra.Imagen = obraDto.Imagen;
            _logger.LogInformation($"Cambiando Imagen de '{obra.Imagen}' a '{obraDto.Imagen}'.");
            var actoresActualizados = new List<ObraActor>();
            foreach (var actorDto in obraDto.Actores)
            {
                var actor = _actorRepository.Get(actorDto.ActorId);
                if (actor != null)
                {
                    actoresActualizados.Add(new ObraActor { ObraID = id, ActorId = actor.ActorId });
                    _logger.LogInformation($"Actor con ID: {actor.ActorId} añadido a la obra con ID: {id}.");
                }
                else
                {
                    _logger.LogWarning($"Actor con ID: {actorDto.ActorId} no encontrado y no se añadirá a la obra con ID: {id}.");
                }
            }

            obra.ObraActores = actoresActualizados;
            _obraRepository.Update(obra, id);
            _logger.LogInformation($"Obra con ID: {id} actualizada correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar la obra con ID: {id}");
            throw;
        }
    }

    public List<ObraDto> GetObrasAleatorias(int id)
    {
        List<ObraDto> obrasAleatorias = new List<ObraDto>();

        for (int i = 0; i < 7; i++)
        {

        }

        var obra = _obraRepository.Get(id);
        if (obra == null) return null;

        var obraDto = new ObraDto
        {
            ObraID = obra.ObraID,
            Titulo = obra.Titulo,
            Director = obra.Director,
            Sinopsis = obra.Sinopsis,
            Duración = obra.Duración,
            Precio = obra.Precio,
            Imagen = obra.Imagen,
            Actores = obra.ObraActores.Select(oa => new ActorDto
            {
                ActorId = oa.ActorId,
                Nombre = oa.Actor?.Nombre
            }).ToList()
        };

        return null;
    }

}
