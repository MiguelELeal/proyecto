using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProcedimientoController : ControllerBase
    {
        private readonly ITipoProcediminetoService _tipService;
        public TipoProcedimientoController(ITipoProcediminetoService tipService)
        {
            _tipService = tipService;
        }
        [HttpGet]
        public async Task<ActionResult<TipoProcedimiento>> GetAll()
        {
            var tip = await _tipService.GetAll();
            return Ok(tip);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProcedimiento>> GetTip(int id)
        {
            var tip = await _tipService.GetTp(id);
            if (tip == null)
            {
                return NotFound();
            }
            return Ok(tip);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<TipoProcedimiento>> PostTipoProcedimiento(string tipo)
        {
            var newTip = await _tipService.CreateTp(tipo);
            return CreatedAtAction(nameof(GetTip), new { id = newTip.IDTipoPro }, newTip);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTípoProcedimiento(int id, string tipo)
        {
            var updatedtip = await _tipService.Update(id, tipo);
            if (updatedtip == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProcedimiento(int id)
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

