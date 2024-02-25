using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ActorRepository : IActorRepository
    {
        private readonly TeatroContext _context;

        public ActorRepository(TeatroContext context)
        {
            _context = context;
        }

        public List<Actor> GetAll()
        {

            return _context.Actores.ToList();
        }

        public Actor? Get(int Id)
        {

            return _context.Actores.AsNoTracking().FirstOrDefault(actor => actor.ActorId == Id);

        }

        public void Add(Actor actor)
        {
            _context.Actores.Add(actor);
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

        public void Update(Actor actor)
        {
            _context.Actores.Update(actor);
            _context.SaveChanges();
        }
    }
}