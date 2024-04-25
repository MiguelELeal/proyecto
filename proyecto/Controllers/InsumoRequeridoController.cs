using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoRequeridoController : ControllerBase
    {
        private readonly IInsumosRequeridosService _insumoService;
        public InsumoRequeridoController(IInsumosRequeridosService insumoService)
        {
            _insumoService = insumoService;
        }
        [HttpGet]
        public async Task<ActionResult<InsumosRequeridos>> GetAll()
        {
            var ins = await _insumoService.GetAll();
            return Ok(ins);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<InsumosRequeridos>> GetIns(int id)
        {
            var ins = await _insumoService.GetIns(id);
            if (ins == null)
            {
                return NotFound();
            }
            return Ok(ins);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<InsumosRequeridos>> PostInsumoRe(int IdInsumo, int IdProcedimiento, int Cantidad)
        {
            var newIns = await _insumoService.CreateIns(IdInsumo, IdProcedimiento, Cantidad);
            return CreatedAtAction(nameof(GetIns), new { id = newIns.IDInRe }, newIns);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsumore(int id, int? IdInsumo, int? IdProcedimiento, int? Cantidad)
        {
            var updatedIns = await _insumoService.Update(id, IdInsumo, IdProcedimiento, Cantidad);
            if (updatedIns == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsumo(int id)
        {
            var result = await _insumoService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
