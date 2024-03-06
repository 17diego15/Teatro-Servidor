using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Data;

public class ObraRepository : IObraRepository
{
    private readonly TeatroContext _context;

    public ObraRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<Obra> GetAll()
    {
        return _context.Obras
        .Include(o => o.ObraActores)
        .ThenInclude(oa => oa.Actor)
        .ToList();
    }

    public Obra? Get(int id)
    {
        return _context.Obras
        .Include(o => o.ObraActores)
        .ThenInclude(oa => oa.Actor)
        .AsNoTracking()
        .FirstOrDefault(o => o.ObraID == id);
    }

    public void Add(Obra obra)
    {
        _context.Obras.Add(obra);
        _context.SaveChanges();
        foreach (var obraActor in obra.ObraActores)
        {
            if (!_context.ObraActores.Any(oa => oa.ObraID == obraActor.ObraID && oa.ActorId == obraActor.ActorId))
            {
                _context.ObraActores.Add(new ObraActor
                {
                    ObraID = obraActor.ObraID,
                    ActorId = obraActor.ActorId
                });
            }
        }
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

    public void Update(Obra obra, int id)
    {
        var obraExistente = _context.Obras.Include(o => o.ObraActores).FirstOrDefault(o => o.ObraID == id);
        if (obraExistente != null)
        {
            _context.Entry(obraExistente).CurrentValues.SetValues(obra);

            foreach (var existingObraActor in obraExistente.ObraActores.ToList())
            {
                if (!obra.ObraActores.Any(oa => oa.ActorId == existingObraActor.ActorId))
                {
                    _context.ObraActores.Remove(existingObraActor);
                }
            }

            foreach (var obraActor in obra.ObraActores)
            {
                var existingActor = obraExistente.ObraActores
                .Where(oa => oa.ActorId == obraActor.ActorId && oa.ObraID == obraActor.ObraID)
                .FirstOrDefault();

                if (existingActor == null)
                {
                    obraExistente.ObraActores.Add(new ObraActor
                    {
                        ObraID = id,
                        ActorId = obraActor.ActorId
                    });
                }
            }
            _context.SaveChanges();
        }
    }

    public List<Obra> GetObrasAleatorias(int id)
    {
        return _context.Obras
        .Include(o => o.ObraActores)
        .ThenInclude(oa => oa.Actor)
        .AsNoTracking()
        .Include(o => o.ObraID == id).ToList();
        //.FirstOrDefault(o => o.ObraID == id);
    }
}
