using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ObrasService
{
    private readonly IObraRepository _obrasRepository;

    public ObrasService(IObraRepository obrasRepository)
    {
        _obrasRepository = obrasRepository;
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
                Nombre = oa.Actor.Nombre
            }).ToList()
        }).ToList();

        return obrasDto;
    }

    public ObrasDTO? Get(int id)
    {
        var obra = _obrasRepository.Get(id);
        if (obra == null) return null;

        return new ObrasDTO
        {
            Titulo = obra.Titulo,
            Director = obra.Director,
            Sinopsis = obra.Sinopsis,
            Duración = obra.Duración,
            Precio = obra.Precio,
            Imagen = obra.Imagen
        };
    }


    public void Add(ObrasDTO obraDto)
    {
        var obra = new Obras
        {
            Titulo = obraDto.Titulo,
            Director = obraDto.Director,
            Sinopsis = obraDto.Sinopsis,
            Duración = obraDto.Duración,
            Precio = obraDto.Precio,
            Imagen = obraDto.Imagen
        };
        _obrasRepository.Add(obra);
    }
    public void Delete(int id)
    {
        _obrasRepository.Delete(id);
    }

    public void Put(ObrasDTO obraDto)
    {
        var obra = _obrasRepository.Get(obraDto.ObraID);
        if (obra == null) return;

        obra.Titulo = obraDto.Titulo;
        obra.Director = obraDto.Director;
        obra.Sinopsis = obraDto.Sinopsis;
        obra.Duración = obraDto.Duración;
        obra.Precio = obraDto.Precio;
        obra.Imagen = obraDto.Imagen;

        _obrasRepository.Put(obra);
    }
}
