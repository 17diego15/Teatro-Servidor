using Models;

namespace Data
{
    public interface IFuncionRepository
    {
        List<Funcion> GetAll(int obraID);
        Funcion? Get(int id);
        void Add(Funcion funcion);
        void Delete(int id);
        void Update(Funcion funcion, int id);
        List<Funcion> GetObras(int id);
        int GetFunciones(int funcionId);
    }
}