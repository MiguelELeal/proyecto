using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Repositories;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaService _paService;
        public PartidaController(IPartidaService paService)
        {
            _paService = paService;
        }
        [HttpGet]
        public async Task<ActionResult<Partida>> GetAll()
        {
            var lo = await _paService.GetAll();
            return Ok(lo);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Partida>> GetPa(int id)
        {
            var lo = await _paService.GetPartida(id);
            if (lo == null)
            {
                return NotFound();
            }
            return Ok(lo);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Partida>> PostPartida([FromBody] Partida partida)
        {
            int IdUsuario = partida.IDUsuarioFK;
            DateOnly fechaInicio = partida.FechaInicio;
            string ubicacion = partida.Ubicacion;
            string nivel = partida.Nivel;
            var newPa = await _paService.CreatePartida(IdUsuario, fechaInicio, ubicacion, nivel);
            return CreatedAtAction(nameof(GetPa), new { id = newPa.IDPartida }, newPa);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutPartida([FromBody] Partida partida)
        {
            int id = partida.IDPartida;
            int? IdUsuario = partida.IDUsuarioFK;
            DateOnly? fechaInicio = partida.FechaInicio;
            string? ubicacion = partida.Ubicacion;
            string? nivel = partida.Nivel;
            var updatedpa = await _paService.Update(id, IdUsuario, fechaInicio,ubicacion,nivel);
            if (updatedpa == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            var result = await _paService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
