using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public List<Usuario> GetAll()
    {
        return _usuarioRepository.GetAll();
    }

    public Usuario? Get(int id)
    {
        return _usuarioRepository.Get(id);
    }

    public void Add(Usuario usuario)
    {
        _usuarioRepository.Add(usuario);
    }

    public void Delete(int id)
    {
        _usuarioRepository.Delete(id);
    }

    public void Update(Usuario usuario)
    {
        _usuarioRepository.Update(usuario);
    }

    public Usuario ValidateCredentials(string nombreUsuario, string contraseña)
    {
        var usuario = _usuarioRepository.GetLogin(nombreUsuario, contraseña);
        return usuario; 
    }
}
