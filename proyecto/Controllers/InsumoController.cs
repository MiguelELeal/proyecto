using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {
        private readonly IInsumosService _insumoService;
        public InsumoController(IInsumosService insumoService)
        {
            _insumoService = insumoService;
        }
        [HttpGet]
        public async Task<ActionResult<Insumos>> GetAll()
        {
            var ins = await _insumoService.GetAll();
            return Ok(ins);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Insumos>> GetIn(int id)
        {
            var ins = await _insumoService.GetInsumo(id);
            if (ins == null)
            {
                return NotFound();
            }
            return Ok(ins);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Insumos>> PostInsumo(string nombre, string descripcion, int stock)
        {
            var newIns = await _insumoService.CreateInsumo(nombre, descripcion, stock);
            return CreatedAtAction(nameof(GetIn), new { id = newIns.IDInsumo }, newIns);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsumo(int id, string? nombre, string? descripcion, int? stock)
        {
            var updatedIns = await _insumoService.Update(id, nombre, descripcion, stock);
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
