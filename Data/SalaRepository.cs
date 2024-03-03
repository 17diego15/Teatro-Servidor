using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Data;

public class SalaRepository : ISalaRepository
{
    private readonly TeatroContext _context;

    public SalaRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<Sala> GetAll()
    {
        return _context.Salas
        .ToList();
    }
    public Sala? Get(int id)
    {
        return _context.Salas
                .AsNoTracking()
                .FirstOrDefault(s => s.SalaID == id);
    }

    public void Add(Sala sala)
    {
        _context.Salas.Add(sala);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var sala = _context.Salas.FirstOrDefault(sala => sala.SalaID == id);
        if (sala != null)
        {
            _context.Salas.Remove(sala);
            _context.SaveChanges();
        }
    }

    public void Update(Sala sala, int id)
    {
        _context.Salas.Update(sala);
        _context.SaveChanges();
    }
}