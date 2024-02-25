using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ActorService
{
    private readonly IActorRepository _actorRepository;

    public ActorService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public List<Actor> GetAll()
    {
        return _actorRepository.GetAll();
    }

    public Actor? Get(int id)
    {
        return _actorRepository.Get(id);
    }

    public void Add(Actor actor)
    {
        _actorRepository.Add(actor);
    }

    public void Delete(int id)
    {
        _actorRepository.Delete(id);
    }

    public void Update(Actor actor)
    {
        _actorRepository.Update(actor);
    }
}
