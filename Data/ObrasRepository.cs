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
        return _context.Obras.ToList();
    }

    public void Add(Obras obras)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Obras? Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Obras> GetUsuarios()
    {
        throw new NotImplementedException();
    }

    public void Put(Obras obras)
    {
        throw new NotImplementedException();
    }
}
