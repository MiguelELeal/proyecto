using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerrenoController : ControllerBase
    {
        private readonly ITerrenoService _teService;
        public TerrenoController(ITerrenoService teService)
        {
            _teService = teService;
        }
        [HttpGet]
        public async Task<ActionResult<Terreno>> GetAll()
        {
            var te = await _teService.GetAll();
            return Ok(te);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Terreno>> GetTe(int id)
        {
            var te = await _teService.GetTe(id);
            if (te == null)
            {
                return NotFound();
            }
            return Ok(te);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Terreno>> PostTerreno([FromBody] Terreno terreno)
        {
            string nombre = terreno.Nombre;
            float area = terreno.Area;
            var newTe = await _teService.CreateTe(nombre, area);
            return CreatedAtAction(nameof(GetTe), new { id = newTe.IDTerreno }, newTe);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutTerreno([FromBody] Terreno terreno)
        {
            int id = terreno.IDTerreno;
            string? nombre = terreno.Nombre;
            float? area = terreno.Area;
            var updatedte = await _teService.Update(id, nombre, area);
            if (updatedte == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerreno(int id)
        {
            var result = await _teService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
