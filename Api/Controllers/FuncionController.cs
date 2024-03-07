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
        public ActionResult<List<FuncionDto>> GetAll(int idObra, int? idUser = 0)
        {
            return _funcionService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<FuncionDto> Get(int id)
        {
            var funcion = _funcionService.Get(id);

            if (funcion == null)
                return NotFound();

            return funcion;
        }

        [HttpPost]
        public IActionResult Create(FuncionPostDto funcionPostDto)
        {
            var funcionId = _funcionService.Add(funcionPostDto);

            return CreatedAtAction(nameof(Get), new { id = funcionId }, funcionPostDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionPostDto funcionPostDto)
        {
            if (id != funcionPostDto.FuncionID)
                return BadRequest();

            var existingFuncion = _funcionService.Get(id);
            if (existingFuncion is null)
                return NotFound();

            _funcionService.Update(funcionPostDto, id);

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

        [HttpGet("/obras/{id}/funcion")]
        public ActionResult GetObras(int id)
        {
            var funcion = _funcionService.GetObras(id);

            if (funcion != null)
            {
                return Ok(funcion);
            }
            else
            {
                return NotFound();
            }
        }
    }
}