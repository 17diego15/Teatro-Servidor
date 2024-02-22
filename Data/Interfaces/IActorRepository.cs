using Models;

namespace Data
{
    public interface IActorRepository
    {
        List<Actores> GetAll();
        Actores? Get(int id);
        void Add(Actores actores);
        void Delete(int id);
        void Put(Actores actores);
    }

}