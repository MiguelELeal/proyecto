using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogrosController : ControllerBase
    {
        private readonly ILogroService _loService;
        public LogrosController(ILogroService loService)
        {
            _loService = loService;
        }
        [HttpGet]
        public async Task<ActionResult<Logro>> GetAll()
        {
            var lo = await _loService.GetAll();
            return Ok(lo);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Logro>> GetLo(int id)
        {
            var lo = await _loService.GetLogro(id);
            if (lo == null)
            {
                return NotFound();
            }
            return Ok(lo);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Logro>> PostLogro([FromBody] Logro logro)
        {
            string nombre = logro.NombreLogro;
            var newLo = await _loService.CreateLogro(nombre);
            return CreatedAtAction(nameof(GetLo), new { id = newLo.IDLogro }, newLo);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutLogro([FromBody] Logro logro)
        {
            int id = logro.IDLogro;
            string? nombre = logro.NombreLogro;
            var updatedLo = await _loService.Update(id, nombre);
            if (updatedLo == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogro(int id)
        {
            var result = await _loService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
