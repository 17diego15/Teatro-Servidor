using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public List<Usuario> GetAll()
    {
        _logger.LogInformation("Obteniendo todas los usuarios.");
        try
        {
            var usuario = _usuarioRepository.GetAll();
            _logger.LogInformation($"Retornados {usuario.Count} usuarios.");
            return usuario;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas los usuarios.");
            throw;
        }

    }

    public Usuario? Get(int id)
    {
        _logger.LogInformation($"Buscando usuario con ID: {id}");
        try
        {
            _logger.LogInformation($"Usuario con ID: {id} encontrado.");
            return _usuarioRepository.Get(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener el usaurio con ID: {id}.");
            throw;
        }
    }

    public void Add(Usuario usuario)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar un nuevo usuario: {JsonSerializer.Serialize(usuario)}");
            _usuarioRepository.Add(usuario);
            _logger.LogInformation($"Usuario agregado con éxito.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar un nuevo usuario");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation($"Intentando eliminar el usuario con ID: {id}");
            _usuarioRepository.Delete(id);
            _logger.LogInformation($"Usuario con ID: {id} eliminado correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar el usuario con ID: {id}");
            throw;
        }
    }

    public void Update(Usuario usuario)
    {
        try
        {
            _logger.LogInformation($"Intentando actualizar el usuario con ID: {usuario.UsuarioID}");
            _usuarioRepository.Update(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar el usuario con ID: {usuario.UsuarioID}");
            throw;
        }
    }

    public Usuario ValidateCredentials(string nombreUsuario, string contraseña)
    {
        try
        {
            _logger.LogInformation($"Intentando validar credenciales para el usuario: {nombreUsuario}");
            var usuario = _usuarioRepository.GetLogin(nombreUsuario, contraseña);
            return usuario;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al validar credenciales del usuario.");
            throw;
        }
    }
}
