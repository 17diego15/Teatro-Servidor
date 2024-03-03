using Models;

namespace Data
{
    public interface ISalaRepository
    {
        List<Sala> GetAll();
        Sala? Get(int id);
        void Add(Sala sala);
        void Delete(int id);
        void Update(Sala sala, int id);
    }

}