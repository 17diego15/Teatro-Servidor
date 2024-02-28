using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Data;

public class ReservaRepository : IReservaRepository
{
    private readonly TeatroContext _context;

    public ReservaRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<Reserva> GetAll()
    {
        return _context.Reservas.ToList();
    }
    public Reserva? Get(int id)
    {
        return _context.Reservas
                .AsNoTracking()
                .FirstOrDefault(r => r.ReservaID == id);
    }

    public List<Reserva>? GetFuncion(int id)
    {
        return _context.Reservas
                .Where(r => r.FunciónID == id)
                .AsNoTracking()
                .ToList();
    }

    public void Add(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var reserva = _context.Reservas.FirstOrDefault(reserva => reserva.ReservaID == id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }
    }

    public void Update(Reserva reserva, int id)
    {
        _context.Reservas.Update(reserva);
        _context.SaveChanges();
    }
}