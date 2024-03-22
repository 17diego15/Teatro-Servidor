using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class FuncionRepository : IFuncionRepository
    {
        private readonly TeatroContext _context;

        public FuncionRepository(TeatroContext context)
        {
            _context = context;
        }

        public List<Funcion> GetAll(int obraID = 0)
        {
            IQueryable<Funcion> query = _context.Funciones
                .Include(f => f.Obra)
                .ThenInclude(o => o.ObraActores)
                .ThenInclude(oa => oa.Actor)
                .Include(f => f.Sala);

            if (obraID > 0)
            {
                query = query.Where(f => f.ObraID == obraID);
            }

            return query.ToList();
        }

        public Funcion? Get(int id)
        {
            return _context.Funciones
                .Include(f => f.Obra)
                .ThenInclude(o => o.ObraActores)
                .ThenInclude(oa => oa.Actor)
                .Include(f => f.Sala)
                .AsNoTracking()
                .FirstOrDefault(funcion => funcion.FuncionID == id);
        }

        public void Add(Funcion funcion)
        {
            _context.Funciones.Add(funcion);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var funcion = _context.Funciones.FirstOrDefault(funcion => funcion.FuncionID == id);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
                _context.SaveChanges();
            }
        }

        public void Update(Funcion funcion, int id)
        {
            _context.Funciones.Update(funcion);

            _context.SaveChanges();
        }

        public List<Funcion> GetObras(int id)
        {
            DateTime now = DateTime.Now;
            return _context.Funciones
                //descomentar cuando se actualicen las fechas
                // .Where(f => f.ObraID == id &&
                //     (f.Fecha.Date > now.Date ||
                //     (f.Fecha.Date == now.Date &&
                //     f.Hora > now.TimeOfDay)))
                .Where(f => f.ObraID == id)
                .Include(f => f.Obra)
                .ThenInclude(o => o.ObraActores)
                .ThenInclude(oa => oa.Actor)
                .Include(f => f.Sala)
                .AsNoTracking()
                .ToList();
        }

        public int GetFunciones(int funcionId)
        {
            return _context.Reservas.Count(r => r.FunciónID == funcionId);
        }
    }
}