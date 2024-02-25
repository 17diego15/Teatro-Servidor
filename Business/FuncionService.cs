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

    public List<Funcion> GetAll()
    {
        return _funcionRepository.GetAll();
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