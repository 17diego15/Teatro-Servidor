using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ReservaService
{
    private readonly IReservaRepository _reservaRepository;

    public ReservaService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public List<Reserva> GetAll()
    {
        return _reservaRepository.GetAll();
    }

    public Reserva? Get(int id)
    {
        return _reservaRepository.Get(id);
    }

    public List<Reserva> GetFuncion(int id)
    {
        return _reservaRepository.GetFuncion(id);
    }

    public void Add(Reserva reserva)
    {
        _reservaRepository.Add(reserva);
    }

    public void Delete(int id)
    {
        _reservaRepository.Delete(id);
    }

    public void Update(Reserva reserva, int id)
    {
        _reservaRepository.Update(reserva, id);
    }
}