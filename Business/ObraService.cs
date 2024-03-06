using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ObraService
{
    private readonly IObraRepository _obraRepository;
    private readonly IActorRepository _actorRepository;


    public ObraService(IObraRepository obraRepository, IActorRepository actorRepository)
    {
        _obraRepository = obraRepository;
        _actorRepository = actorRepository;
    }

    public List<ObraDto> GetAll()
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

        return obraDto;
    }

    public ObraDto? Get(int id)
    {
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
        return obraDto;
    }


    public int Add(ObraDto obraDto)
    {
        var obraActores = new List<ObraActor>();

        foreach (var actorDto in obraDto.Actores)
        {
            var actorExists = _actorRepository.Get(actorDto.ActorId);
            if (actorExists == null)
            {
                throw new ArgumentException($"El actor con ID {actorDto.ActorId} no existe en la base de datos.");
            }
            else
            {
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
        return obra.ObraID;
    }
    public void Delete(int id)
    {
        _obraRepository.Delete(id);
    }

    public void Update(ObraDto obraDto, int id)
    {
        var obra = _obraRepository.Get(id);
        if (obra == null) return;

        obra.Titulo = obraDto.Titulo;
        obra.Director = obraDto.Director;
        obra.Sinopsis = obraDto.Sinopsis;
        obra.Duración = obraDto.Duración;
        obra.Precio = obraDto.Precio;
        obra.Imagen = obraDto.Imagen;
        var actoresActualizados = new List<ObraActor>();
        foreach (var actorDto in obraDto.Actores)
        {
            var actor = _actorRepository.Get(actorDto.ActorId);
            if (actor != null)
            {
                actoresActualizados.Add(new ObraActor { ObraID = id, ActorId = actor.ActorId });
            }
        }

        obra.ObraActores = actoresActualizados;
        _obraRepository.Update(obra, id);
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
