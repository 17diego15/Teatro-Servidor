using Models;

namespace Data;

public interface IReservaRepository
{
    List<Reserva> GetAll();
    Reserva? Get(int id);
    List<Reserva> GetFuncion(int id);
    void Add(Reserva reserva);
    void Delete(int id);
    void Update(Reserva reserva, int id);
}

