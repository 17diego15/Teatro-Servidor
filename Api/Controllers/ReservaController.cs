using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public ActionResult<List<ReservaDto>> GetAll()
        {
            return _reservaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Reserva> Get(int id)
        {
            var reserva = _reservaService.Get(id);

            if (reserva == null)
                return NotFound();

            return reserva;
        }

        [HttpGet("/funcion/{id}/reservas")]
        public ActionResult<List<ReservaDto>> GetFuncion(int id)
        {
            var funcion = _reservaService.GetFuncion(id);

            if (funcion == null)
                return NotFound();

            return funcion;
        }

        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            _reservaService.Add(reserva);
            return CreatedAtAction(nameof(Get), new { id = reserva.ReservaID }, reserva);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Reserva reserva)
        {
            var existingReserva = _reservaService.Get(id);
            if (existingReserva == null) return NotFound();

            _reservaService.Update(reserva, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reserva = _reservaService.Get(id);

            if (reserva is null)
                return NotFound();

            _reservaService.Delete(id);

            return NoContent();
        }
    }
}