using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class FuncionService
{
    private readonly IFuncionRepository _funcionRepository;

    public FuncionService(IFuncionRepository funcionRepository)
    {
        _funcionRepository = funcionRepository;
    }

    public List<FuncionDto> GetAll()
    {
        var funciones = _funcionRepository.GetAll();

        var funcionDtos = funciones.Select(f => new FuncionDto
        {
            FuncionID = f.FuncionID,
            ObraID = f.ObraID,
            SalaID = f.SalaID,
            Fecha = f.Fecha,
            Hora = f.Hora,
            Disponibilidad = f.Disponibilidad,

            Obra = new ObraDto
            {
                ObraID = f.Obra.ObraID,
                Titulo = f.Obra.Titulo,
                Director = f.Obra.Director,
                Sinopsis = f.Obra.Sinopsis,
                Duración = f.Obra.Duración,
                Precio = f.Obra.Precio,
                Imagen = f.Obra.Imagen,
                Actores = f.Obra.ObraActores.Select(oa => new ActorDto
                {
                    ActorId = oa.ActorId,
                    Nombre = oa.Actor.Nombre
                }).ToList()
            }
        }).ToList();

        return funcionDtos;
    }

    public FuncionDto? Get(int id)
    {
        var funcion = _funcionRepository.Get(id);
        if (funcion == null) return null;
        var funcionDto = new FuncionDto
        {
            FuncionID = funcion.FuncionID,
            ObraID = funcion.ObraID,
            SalaID = funcion.SalaID,
            Fecha = funcion.Fecha,
            Hora = funcion.Hora,
            Disponibilidad = funcion.Disponibilidad,

            Obra = new ObraDto
            {
                ObraID = funcion.Obra.ObraID,
                Titulo = funcion.Obra.Titulo,
                Director = funcion.Obra.Director,
                Sinopsis = funcion.Obra.Sinopsis,
                Duración = funcion.Obra.Duración,
                Precio = funcion.Obra.Precio,
                Imagen = funcion.Obra.Imagen,
                Actores = funcion.Obra.ObraActores.Select(oa => new ActorDto
                {
                    ActorId = oa.ActorId,
                    Nombre = oa.Actor.Nombre
                }).ToList() ?? new List<ActorDto>()
            }
        };

        return funcionDto;
    }

    public void Add(Funcion funcion)
    {
        _funcionRepository.Add(funcion);
    }

    public void Delete(int id)
    {
        _funcionRepository.Delete(id);
    }

    public void Update(Funcion funcion, int id)
    {
        _funcionRepository.Update(funcion, id);
    }

    public List<FuncionDto> GetObras(int id)
    {
        var obras = _funcionRepository.GetObras(id);
        if (obras == null || !obras.Any()) return null;

        var funcionDtos = obras.Select(obra => new FuncionDto
        {
            FuncionID = obra.FuncionID,
            ObraID = obra.ObraID,
            SalaID = obra.SalaID,
            Fecha = obra.Fecha,
            Hora = obra.Hora,
            Disponibilidad = obra.Disponibilidad,
            Obra = new ObraDto
            {
                ObraID = obra.Obra.ObraID,
                Titulo = obra.Obra.Titulo,
                Director = obra.Obra.Director,
                Sinopsis = obra.Obra.Sinopsis,
                Duración = obra.Obra.Duración,
                Precio = obra.Obra.Precio,
                Imagen = obra.Obra.Imagen,
                Actores = obra.Obra.ObraActores.Select(oa => new ActorDto
                {
                    ActorId = oa.ActorId,
                    Nombre = oa.Actor.Nombre
                }).ToList()
            }
        }).ToList();

        return funcionDtos;
    }
}