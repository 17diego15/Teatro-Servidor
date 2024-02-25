using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionController : ControllerBase
    {
        private readonly FuncionService _funcionService;

        public FuncionController(FuncionService funcionService)
        {
            _funcionService = funcionService;
        }

        [HttpGet]
        public ActionResult<List<Funcion>> GetAll()
        {
            return _funcionService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Funcion> Get(int id)
        {
            var funcion = _funcionService.Get(id);

            if (funcion == null)
                return NotFound();

            return funcion;
        }

        [HttpPost]
        public IActionResult Create(Funcion funcion)
        {
            _funcionService.Add(funcion);
            return CreatedAtAction(nameof(Get), new { id = funcion.FuncionID }, funcion);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Funcion funcion)
        {
            if (id != funcion.FuncionID)
                return BadRequest();

            var existingFuncion = _funcionService.Get(id);
            if (existingFuncion is null)
                return NotFound();

            _funcionService.Update(funcion, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcion = _funcionService.Get(id);

            if (funcion is null)
                return NotFound();

            _funcionService.Delete(id);

            return NoContent();
        }
    }
}