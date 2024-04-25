using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPartidaController : ControllerBase
    {
        private readonly IDatosPartidaService _datosService;
        public DatosPartidaController(IDatosPartidaService datosService)
        {
            _datosService = datosService;
        }
        [HttpGet]
        public async Task<ActionResult<DatosPartida>> GetAll()
        {
            var dp = await _datosService.GetAll();
            return Ok(dp);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<DatosPartida>> GetDaP(int id)
        {
            var dp = await _datosService.GetDp(id);
            if (dp == null)
            {
                return NotFound();
            }
            return Ok(dp);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<DatosPartida>> PostDatosPartida(int IdPartida, int IdProcedimiento)
        {
            var newDatos = await _datosService.CreateDp(IdPartida, IdProcedimiento);
            return CreatedAtAction(nameof(GetDaP), new { id = newDatos.IdDatosJugador }, newDatos);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatosParitda(int id, int? IdPartida, int? IdProcedimiento)
        {
            var updatedDp = await _datosService.Update(id, IdPartida, IdProcedimiento);
            if (updatedDp == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatosPartida(int id)
        {
            var result = await _datosService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
