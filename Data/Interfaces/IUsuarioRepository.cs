using Models;

namespace Data;

public interface IUsuarioRepository
{
    List<Usuario> GetAll();
    Usuario? Get(int id);
    List<Usuario> GetUsuarios();
    void Add(Usuario usuario);
    void Delete(int id);
    void Update(Usuario usuario);
    Usuario GetLogin(string nombreUsuario, string contraseña);
}