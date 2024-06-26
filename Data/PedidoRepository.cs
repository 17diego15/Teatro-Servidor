using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly TeatroContext _context;

        public PedidoRepository(TeatroContext context)
        {
            _context = context;
        }

        public List<Pedido> GetAll(int UsuarioID)
        {
            IQueryable<Pedido> query = _context.Pedidos
            .Include(p => p.Usuario)
            .Include(p => p.Funcion)
            .Include(p => p.Reservas);
            if (UsuarioID > 0)
            {
                query = query.Where(p => p.UsuarioID == UsuarioID);
            }
            return query.ToList();
        }

        public Pedido? Get(int id)
        {
            return _context.Pedidos
            .Include(p => p.Usuario)
            .Include(p => p.Funcion)
            .Include(p => p.Reservas)
            .AsNoTracking()
            .FirstOrDefault(p => p.PedidoID == id);
        }

        public void Add(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }
    }
}