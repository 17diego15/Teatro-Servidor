using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ActoresService _actoresService;

        public ActorController(ActoresService actoresService)
        {
            _actoresService = actoresService;
        }

        [HttpGet]
        public ActionResult<List<Actores>> GetAll()
        {
            return _actoresService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Actores> Get(int id)
        {
            var actor = _actoresService.Get(id);

            if (actor == null)
                return NotFound();

            return actor;
        }

        [HttpPost]
        public IActionResult Create(Actores actor)
        {
            _actoresService.Add(actor);
            return CreatedAtAction(nameof(Get), new { id = actor.ActorId }, actor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Actores actor)
        {
            if (id != actor.ActorId)
                return BadRequest();

            var existingActor = _actoresService.Get(id);
            if (existingActor is null)
                return NotFound();

            _actoresService.Put(actor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var actor = _actoresService.Get(id);

            if (actor is null)
                return NotFound();

            _actoresService.Delete(id);

            return NoContent();
        }
    }
}