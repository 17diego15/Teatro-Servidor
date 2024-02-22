using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ActoresService
{
    private readonly IActorRepository _actorRepository;

    public ActoresService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public List<Actores> GetAll()
    {
        return _actorRepository.GetAll();
    }

    public Actores? Get(int id)
    {
        return _actorRepository.Get(id);
    }

    public void Add(Actores actores)
    {
        _actorRepository.Add(actores);
    }

    public void Delete(int id)
    {
        _actorRepository.Delete(id);
    }

    public void Put(Actores actores)
    {
        _actorRepository.Put(actores);
    }
}
