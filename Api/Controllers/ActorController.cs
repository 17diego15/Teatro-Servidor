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
        private readonly ActorService _actorService;

        public ActorController(ActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public ActionResult<List<Actor>> GetAll()
        {
            return _actorService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> Get(int id)
        {
            var actor = _actorService.Get(id);

            if (actor == null)
                return NotFound();

            return actor;
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            _actorService.Add(actor);
            return CreatedAtAction(nameof(Get), new { id = actor.ActorId }, actor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Actor actor)
        {
            if (id != actor.ActorId)
                return BadRequest();

            var existingActor = _actorService.Get(id);
            if (existingActor is null)
                return NotFound();

            _actorService.Update(actor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var actor = _actorService.Get(id);

            if (actor is null)
                return NotFound();

            _actorService.Delete(id);

            return NoContent();
        }
    }
}