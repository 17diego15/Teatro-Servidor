using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(UsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;

        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todas los usuarios.");
                return _usuarioService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los usuarios.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de usuarios.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando usuario con ID: {id}");
                var usuario = _usuarioService.Get(id);

                if (usuario == null)
                {
                    _logger.LogWarning($"Usuario con ID: {id} no encontrada.");
                    return NotFound();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el usuario con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener el usuario.");
            }
        }

        [HttpPost("login")]
        public ActionResult Login(string nombreUsuario, string contraseña)
        {
            try
            {
                _logger.LogInformation($"Intento de inicio de sesión del usuario: {nombreUsuario}");
                var usuario = _usuarioService.ValidateCredentials(nombreUsuario, contraseña);

                if (usuario != null)
                {
                    _logger.LogInformation($"Usuario {nombreUsuario} autenticado correctamente");
                    return Ok(usuario);
                }
                else
                {
                    _logger.LogInformation($"Autenticación fallida para el usuario: {nombreUsuario}");
                    return Unauthorized("Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al realizar el inicio de sesión.");
                return StatusCode(500, "Se produjo un error al intentar iniciar sesión.");
            }
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            try
            {
                _logger.LogInformation($"Creando nuevo usuario con ID: {usuario.UsuarioID}");
                _usuarioService.Add(usuario);
                return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioID }, usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear el usuario.");
                return StatusCode(500, "Un error ocurrió al crear el usuario.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                _logger.LogInformation($"Actualizando usuario con ID: {id}");
                if (id != usuario.UsuarioID)
                {
                    _logger.LogWarning($"No se puede actualizar: Usuario con ID: {id} no encontrada.");
                    return BadRequest();
                }

                var existingUsuario = _usuarioService.Get(id);
                if (existingUsuario is null)
                    return NotFound();

                _usuarioService.Update(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar el usuario con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar el usuario.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando usuario con ID: {id}");
                var usuario = _usuarioService.Get(id);

                if (usuario is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Usuario con ID: {id} no encontrado.");
                    return NotFound();
                }

                _usuarioService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar el usuario con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar el usuario.");
            }
        }
    }
}