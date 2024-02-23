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
        public ActionResult<List<ObrasDTO>> GetAll()
        {
            return _obrasService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ObrasDTO> Get(int id)
        {
            var obra = _obrasService.Get(id);

            if (obra == null)
                return NotFound();

            return obra;
        }

        [HttpPost]
        public IActionResult Create(ObrasDTO obrasDto)
        {
            var obraId = _obrasService.Add(obrasDto);
            return CreatedAtAction(nameof(Get), new { id = obraId }, obrasDto);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, ObrasDTO obras)
        {
            var existingObra = _obrasService.Get(id);
            if (existingObra == null) return NotFound();

            _obrasService.Put(obras, id);

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