using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObrasController : ControllerBase
    {
        private readonly ObrasService _obrasService;

        public ObrasController(ObrasService obrasService)
        {
            _obrasService = obrasService;
        }

        [HttpGet]
        public ActionResult<List<Obras>> GetAll()
        {
            return _obrasService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Obras> Get(int id)
        {
            var usuario = _obrasService.Get(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost]
        public IActionResult Create(Obras obras)
        {
            _obrasService.Add(obras);
            return CreatedAtAction(nameof(Get), new { id = obras.ObraID }, obras);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Obras obras)
        {
            if (id != obras.ObraID)
                return BadRequest();

            var existingObra = _obrasService.Get(id);
            if (existingObra is null)
                return NotFound();

            _obrasService.Put(obras);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obras = _obrasService.Get(id);

            if (obras is null)
                return NotFound();

            _obrasService.Delete(id);

            return NoContent();
        }
    }
}