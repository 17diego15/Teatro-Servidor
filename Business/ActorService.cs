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

    public List<ActorDto> GetAll()
    {
        var actor = _actorRepository.GetAll();

        var actorDto = actor.Select(o => new ActorDto
        {
            ActorId = o.ActorId,
            Nombre = o.Nombre
        }).ToList();
        return actorDto;
    }

    public ActorDto? Get(int id)
    {
        var actor = _actorRepository.Get(id);
        if (actor == null) return null;

        var actorDto = new ActorDto
        {
            ActorId = actor.ActorId,
            Nombre = actor.Nombre
        };
        return actorDto;

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
