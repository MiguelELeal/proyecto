using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Repositories;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogroConseguidoController : ControllerBase
    {
        private readonly ILogroConseguidoService _loService;
        public LogroConseguidoController(ILogroConseguidoService loService)
        {
            _loService = loService;
        }
        [HttpGet]
        public async Task<ActionResult<LogroConseguido>> GetAll()
        {
            var lo = await _loService.GetAll();
            return Ok(lo);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<LogroConseguido>> GetLo(int id)
        {
            var lo = await _loService.GetLoCo(id);
            if (lo == null)
            {
                return NotFound();
            }
            return Ok(lo);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<LogroConseguido>> PostLogro(int IdPartida, int IdLogro, DateOnly fechaLogro)
        {
            var newLo = await _loService.CreateLoCo(IdPartida,IdLogro,fechaLogro);
            return CreatedAtAction(nameof(GetLo), new { id = newLo.IDLogCon }, newLo);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogro(int id, int IdPartida, int IdLogro, DateOnly fechaLogro)
        {
            var updatedLo = await _loService.Update(id, IdPartida, IdLogro, fechaLogro);
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
