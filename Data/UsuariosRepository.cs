using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TeatroContext _context;

        public UsuarioRepository(TeatroContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll()
        {

            return _context.Usuarios.ToList();
        }

        public Usuario? Get(int Id)
        {

            return _context.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.UsuarioID == Id);

        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.UsuarioID == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public void Put(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> GetUsuarios() => GetAll();
    }
}