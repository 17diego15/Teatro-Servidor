using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ActoresRepository : IActorRepository
    {
        private readonly TeatroContext _context;

        public ActoresRepository(TeatroContext context)
        {
            _context = context;
        }

        public List<Actores> GetAll()
        {

            return _context.Actores.ToList();
        }

        public Actores? Get(int Id)
        {

            return _context.Actores.AsNoTracking().FirstOrDefault(actor => actor.ActorId == Id);

        }

        public void Add(Actores actores)
        {
            _context.Actores.Add(actores);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var actor = _context.Actores.FirstOrDefault(actor => actor.ActorId == id);
            if (actor != null)
            {
                _context.Actores.Remove(actor);
                _context.SaveChanges();
            }
        }

        public void Put(Actores actores)
        {
            _context.Actores.Update(actores);
            _context.SaveChanges();
        }
    }
}