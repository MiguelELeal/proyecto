using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivoController : ControllerBase
    {
        private readonly ICultivoService _cultivoService;
        public CultivoController(ICultivoService cultivoService)
        {
            _cultivoService = cultivoService;
        }
        [HttpGet]
        public async Task<ActionResult<Cultivo>> GetAll()
        {
            var cul = await _cultivoService.GetAll();
            return Ok(cul);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Cultivo>> GetCul(int id)
        {
            var cul = await _cultivoService.GetCultivo(id);
            if (cul == null)
            {
                return NotFound();
            }
            return Ok(cul);
        }
        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult<Cultivo>> PostCultivo([FromBody] Cultivo cultivo)
        {
            int IdSiembra = cultivo.IdSiembraFK;
            DateOnly FechaCosE = cultivo.FechaCosechaE;
            int IdEstado = cultivo.IdEstadoFK;
            DateOnly FechaModificacion = cultivo.FechaModificacion;
            var newCul = await _cultivoService.CreateCultivo(IdSiembra,FechaCosE,IdEstado,FechaModificacion);
            return CreatedAtAction(nameof(GetCul), new { id = newCul.IDCultivo }, newCul);
        }
        // PUT: api/Rol
        [HttpPut]
        public async Task<IActionResult> PutCultivo([FromBody] Cultivo cultivo)
        {
            int id = cultivo.IDCultivo;
            int? IdSiembra = cultivo.IdSiembraFK;
            DateOnly? FechaCosE = cultivo.FechaCosechaE;
            int? IdEstado = cultivo.IdEstadoFK;
            DateOnly? FechaModificacion = cultivo.FechaModificacion;
            var updatedEsta = await _cultivoService.Update(id, IdSiembra, FechaCosE, IdEstado, FechaModificacion);
            if (updatedEsta == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/Crops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCultivo(int id)
        {
            var result = await _cultivoService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
