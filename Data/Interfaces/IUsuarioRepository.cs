using Models;

namespace Data;

    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario? Get(int id);
        List<Usuario> GetUsuarios();
        void Add(Usuario usuario);
        void Delete(int id);
        void Put(Usuario usuario);
    }