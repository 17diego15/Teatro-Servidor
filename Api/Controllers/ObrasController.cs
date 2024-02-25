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
        private readonly ObraService _obraService;

        public ObrasController(ObraService obraService)
        {
            _obraService = obraService;
        }

        [HttpGet]
        public ActionResult<List<ObraDto>> GetAll()
        {
            return _obraService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ObraDto> Get(int id)
        {
            var obra = _obraService.Get(id);

            if (obra == null)
                return NotFound();

            return obra;
        }

        [HttpPost]
        public IActionResult Create(ObraDto obrasDto)
        {
            var obraId = _obraService.Add(obrasDto);
            return CreatedAtAction(nameof(Get), new { id = obraId }, obrasDto);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, ObraDto obra)
        {
            var existingObra = _obraService.Get(id);
            if (existingObra == null) return NotFound();

            _obraService.Update(obra, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obra = _obraService.Get(id);

            if (obra is null)
                return NotFound();

            _obraService.Delete(id);

            return NoContent();
        }
    }
}