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
        public async Task<ActionResult<Partida>> PostPartida(int IdUsuario, DateOnly fechaInicio)
        {
            var newPa = await _paService.CreatePartida(IdUsuario, fechaInicio);
            return CreatedAtAction(nameof(GetPa), new { id = newPa.IDPartida }, newPa);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartida(int id, int IdUsuario, DateOnly fechaInicio)
        {
            var updatedpa = await _paService.Update(id, IdUsuario, fechaInicio);
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
