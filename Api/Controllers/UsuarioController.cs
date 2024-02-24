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

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return _usuarioService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost("login")]
        public ActionResult Login(string nombreUsuario, string contraseña)
        {
            var usuario = _usuarioService.ValidateCredentials(nombreUsuario, contraseña);

            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return Unauthorized("Credenciales incorrectas");
            }
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioID }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioID)
                return BadRequest();

            var existingUsuario = _usuarioService.Get(id);
            if (existingUsuario is null)
                return NotFound();

            _usuarioService.Put(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario is null)
                return NotFound();

            _usuarioService.Delete(id);

            return NoContent();
        }
    }
}