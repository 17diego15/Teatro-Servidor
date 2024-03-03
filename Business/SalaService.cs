using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class SalaService
{
    private readonly ISalaRepository _salaRepository;

    public SalaService(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public List<Sala> GetAll()
    {
        return _salaRepository.GetAll();
    }

    public Sala? Get(int id)
    {
        return _salaRepository.Get(id);
    }

    public void Add(Sala sala)
    {
        _salaRepository.Add(sala);
    }

    public void Delete(int id)
    {
        _salaRepository.Delete(id);
    }

    public void Update(Sala sala, int id)
    {
        _salaRepository.Update(sala, id);
    }
}