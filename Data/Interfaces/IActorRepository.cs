using Models;

namespace Data
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor? Get(int id);
        void Add(Actor actor);
        void Delete(int id);
        void Update(Actor actor);
    }

}