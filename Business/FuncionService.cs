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
            Desponibilidad = f.Desponibilidad,

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

    public Funcion? Get(int id)
    {
        return _funcionRepository.Get(id);
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
}