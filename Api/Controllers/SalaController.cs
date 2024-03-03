using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _salaService;

        public SalaController(SalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public ActionResult<List<Sala>> GetAll()
        {
            return _salaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> Get(int id)
        {
            var sala = _salaService.Get(id);

            if (sala == null)
                return NotFound();

            return sala;
        }

        [HttpPost]
        public IActionResult Create(Sala sala)
        {
            _salaService.Add(sala);
            return CreatedAtAction(nameof(Get), new { id = sala.SalaID }, sala);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Sala sala)
        {
            var existingSala = _salaService.Get(id);
            if (existingSala == null) return NotFound();

            _salaService.Update(sala, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sala = _salaService.Get(id);

            if (sala is null)
                return NotFound();

            _salaService.Delete(id);

            return NoContent();
        }
    }
}