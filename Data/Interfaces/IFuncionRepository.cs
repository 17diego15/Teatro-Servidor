using Models;

namespace Data
{
    public interface IFuncionRepository
    {
        List<Funcion> GetAll();
        Funcion? Get(int id);
        void Add(Funcion funcion);
        void Delete(int id);
        void Update(Funcion funcion, int id);
    }

}