using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoController : ControllerBase
    {
        private readonly IProcedimientoService _proService;
        public ProcedimientoController(IProcedimientoService proService)
        {
            _proService = proService;
        }
        [HttpGet]
        public async Task<ActionResult<Procedimento>> GetAll()
        {
            var pro = await _proService.GetAll();
            return Ok(pro);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Procedimento>> GetPro(int id)
        {
            var pro = await _proService.GetPro(id);
            if (pro == null)
            {
                return NotFound();
            }
            return Ok(pro);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Procedimento>> PostProcedimiento([FromBody] Procedimento procedimento)
        {
            int IdCultivo = procedimento.IDCultivoFK;
            int IdTPro = procedimento.IDTipoProcedimientoFK;
            DateOnly fechaPro = procedimento.FechaProcedimiento;
            string descrip = procedimento.Descripcion;
            var newPro = await _proService.CreatePro(IdCultivo, IdTPro,fechaPro,descrip);
            return CreatedAtAction(nameof(GetPro), new { id = newPro.IDProcedimiento }, newPro);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutProcedimiento([FromBody] Procedimento procedimento)
        {
            int id = procedimento.IDProcedimiento;
            int? IdCultivo = procedimento.IDCultivoFK;
            int? IdTPro = procedimento.IDTipoProcedimientoFK;
            DateOnly? fechaPro = procedimento.FechaProcedimiento;
            string? descrip = procedimento.Descripcion;
            var updatedpro = await _proService.Update(id, IdCultivo, IdTPro, fechaPro, descrip);
            if (updatedpro == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedimiento(int id)
        {
            var result = await _proService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
