using Models;

namespace Data
{
    public interface IObraRepository
    {
        List<Obras> GetAll();
        Obras? Get(int id);
        void Add(Obras obras);
        void Delete(int id);
        void Put(Obras obras, int id);
    }

}