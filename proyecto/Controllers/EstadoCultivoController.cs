using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCultivoController : ControllerBase
    {
        private readonly IEStadoCultivoService _estaService;
        public EstadoCultivoController(IEStadoCultivoService estaService)
        {
            _estaService = estaService;
        }
        [HttpGet]
        public async Task<ActionResult<EstadoCultivo>> GetAll()
        {
            var esta = await _estaService.GetAll();
            return Ok(esta);
        }

        // GET: api/Rol/
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCultivo>> GetEsta(int id)
        {
            var esta = await _estaService.GetEsta(id);
            if (esta == null)
            {
                return NotFound();
            }
            return Ok(esta);
        }
        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult<EstadoCultivo>> PostEsta(string nombre)
        {
            var newEsta = await _estaService.CreateEsta(nombre);
            return CreatedAtAction(nameof(GetEsta), new { id = newEsta.IDEstado }, newEsta);
        }
        // PUT: api/Rol
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, string nombre)
        {
            var updatedEsta = await _estaService.Update(id, nombre);
            if (updatedEsta == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/Crops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var result = await _estaService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
