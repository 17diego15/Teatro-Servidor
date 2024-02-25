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

        public List<Funcion> GetAll()
        {
            return _context.Funciones.ToList();
        }

        public Funcion? Get(int id)
        {
            return _context.Funciones.AsNoTracking().FirstOrDefault(funcion => funcion.FuncionID == id);
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
    }
}