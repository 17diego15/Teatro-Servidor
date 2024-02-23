using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Data;

public class ObrasRepository : IObraRepository
{
    private readonly TeatroContext _context;

    public ObrasRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<Obras> GetAll()
    {
        return _context.Obras
                   .Include(o => o.ObraActores)
                       .ThenInclude(oa => oa.Actor)
                   .ToList();

    }

    public Obras? Get(int id)
    {
        return _context.Obras.Include(o => o.ObraActores).ThenInclude(oa => oa.Actor).AsNoTracking().FirstOrDefault(o => o.ObraID == id);
    }

    public void Add(Obras obras)
    {
        _context.Obras.Add(obras);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obras = _context.Obras.FirstOrDefault(obras => obras.ObraID == id);
        if (obras != null)
        {
            _context.Obras.Remove(obras);
            _context.SaveChanges();
        }
    }

    public void Put(Obras obras, int id)
    {
        _context.Obras.Update(obras);
        _context.SaveChanges();
    }
}
