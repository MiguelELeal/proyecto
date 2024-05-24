using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _tipService;
        public TipoDocumentoController(ITipoDocumentoService tipService)
        {
            _tipService = tipService;
        }
        [HttpGet]
        public async Task<ActionResult<TipoDocumento>> GetAll()
        {
            var tip = await _tipService.GetAll();
            return Ok(tip);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> GetTip(int id)
        {
            var tip = await _tipService.GetTD(id);
            if (tip == null)
            {
                return NotFound();
            }
            return Ok(tip);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<TipoDocumento>> PostTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            string tipo = tipoDocumento.TipoDo;
            var newTip = await _tipService.CreateTD(tipo);
            return CreatedAtAction(nameof(GetTip), new { id = newTip.IDTipoDoc }, newTip);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutTípoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            int id = tipoDocumento.IDTipoDoc;
            string? tipo = tipoDocumento.TipoDo;
            var updatedtip = await _tipService.Update(id,tipo);
            if (updatedtip == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerreno(int id)
        {
            var result = await _tipService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
