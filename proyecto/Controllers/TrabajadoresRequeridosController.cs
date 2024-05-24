using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresRequeridosController : ControllerBase
    {
        private readonly ITrabajadoresRequeridosService _traService;
        public TrabajadoresRequeridosController(ITrabajadoresRequeridosService traService)
        {
            _traService = traService;
        }
        [HttpGet]
        public async Task<ActionResult<TrabajadoresRequeridos>> GetAll()
        {
            var tra = await _traService.GetAll();
            return Ok(tra);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajadoresRequeridos>> GetTra(int id)
        {
            var tra = await _traService.GetTr(id);
            if (tra == null)
            {
                return NotFound();
            }
            return Ok(tra);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<TrabajadoresRequeridos>> PostTrabajadoresRequeridos([FromBody] TrabajadoresRequeridos trabajadoresRequeridos)
        {
            int IdTrabador = trabajadoresRequeridos.IDTrabjadorFK;
            int IdProcedimiento = trabajadoresRequeridos.IDProcedimientoFK;
            var newTra = await _traService.CreateTr(IdTrabador,IdProcedimiento);
            return CreatedAtAction(nameof(GetTra), new { id = newTra.IDTraRe }, newTra);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutTrabajadoresRequeridos([FromBody] TrabajadoresRequeridos trabajadoresRequeridos)
        {
            int id = trabajadoresRequeridos.IDTraRe;
            int? IdTrabador = trabajadoresRequeridos.IDTrabjadorFK;
            int? IdProcedimiento = trabajadoresRequeridos.IDProcedimientoFK;
            var updatedtra = await _traService.Update(id, IdTrabador, IdProcedimiento);
            if (updatedtra == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajadoresRequeridos(int id)
        {
            var result = await _traService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
