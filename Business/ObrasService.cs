using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ObrasService
{
    private readonly IObraRepository _obrasRepository;
    private readonly IActorRepository _actorRepository;


    public ObrasService(IObraRepository obrasRepository, IActorRepository actorRepository)
    {
        _obrasRepository = obrasRepository;
        _actorRepository = actorRepository;
    }

    public List<ObrasDTO> GetAll()
    {
        var obras = _obrasRepository.GetAll();

        var obrasDto = obras.Select(o => new ObrasDTO
        {
            ObraID = o.ObraID,
            Titulo = o.Titulo,
            Director = o.Director,
            Sinopsis = o.Sinopsis,
            Duración = o.Duración,
            Precio = o.Precio,
            Imagen = o.Imagen,
            Actores = o.ObraActores.Select(oa => new ActorDTO
            {
                ActorId = oa.ActorId,
                Nombre = oa.Actor?.Nombre
            }).ToList()
        }).ToList();

        return obrasDto;
    }

    public ObrasDTO? Get(int id)
    {
        var obra = _obrasRepository.Get(id);
        if (obra == null) return null;


        var obrasDto = new ObrasDTO
        {
            ObraID = obra.ObraID,
            Titulo = obra.Titulo,
            Director = obra.Director,
            Sinopsis = obra.Sinopsis,
            Duración = obra.Duración,
            Precio = obra.Precio,
            Imagen = obra.Imagen,
            Actores = obra.ObraActores.Select(oa => new ActorDTO
            {
                ActorId = oa.ActorId,
                Nombre = oa.Actor?.Nombre 
            }).ToList()
        };
        return obrasDto;
    }


    public int Add(ObrasDTO obraDto)
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

        var obra = new Obras
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
        _obrasRepository.Add(obra);
        return obra.ObraID;
    }
    public void Delete(int id)
    {
        _obrasRepository.Delete(id);
    }

    public void Put(ObrasDTO obraDto, int id)
    {
        var obra = _obrasRepository.Get(id);
        if (obra == null) return;

        obra.Titulo = obraDto.Titulo;
        obra.Director = obraDto.Director;
        obra.Sinopsis = obraDto.Sinopsis;
        obra.Duración = obraDto.Duración;
        obra.Precio = obraDto.Precio;
        obra.Imagen = obraDto.Imagen;

        _obrasRepository.Put(obra, id);
    }
}
