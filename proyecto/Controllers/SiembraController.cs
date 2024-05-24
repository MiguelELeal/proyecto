using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiembraController : ControllerBase
    {
        private readonly ISiembraService _sieService;
        public SiembraController(ISiembraService sieService)
        {
            _sieService = sieService;
        }
        [HttpGet]
        public async Task<ActionResult<Siembra>> GetAll()
        {
            var sie = await _sieService.GetAll();
            return Ok(sie);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Siembra>> GetSie(int id)
        {
            var sie = await _sieService.GetSie(id);
            if (sie == null)
            {
                return NotFound();
            }
            return Ok(sie);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Siembra>> PostSiembra([FromBody] Siembra siembra)
        {
            DateOnly fechaSie = siembra.FechaSiembra;
            float Area = siembra.AreaTotalS;
            int IdTe = siembra.IDTerrenoFK;
            var newSie = await _sieService.CreateSie(fechaSie,Area, IdTe);
            return CreatedAtAction(nameof(GetSie), new { id = newSie.IDSiembra }, newSie);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutSiembra([FromBody] Siembra siembra)
        {
            int id = siembra.IDSiembra;
            DateOnly? fechaSie = siembra.FechaSiembra;
            float? Area = siembra.AreaTotalS;
            int? IdTe = siembra.IDTerrenoFK;
            var updatedsie = await _sieService.Update(id, fechaSie, Area, IdTe);
            if (updatedsie == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiembra(int id)
        {
            var result = await _sieService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
