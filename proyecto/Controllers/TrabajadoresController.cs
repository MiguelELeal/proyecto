using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ITrabajadoresService _traService;
        public TrabajadoresController(ITrabajadoresService traService)
        {
            _traService = traService;
        }
        [HttpGet]
        public async Task<ActionResult<Trabajadores>> GetAll()
        {
            var tra = await _traService.GetAll();
            return Ok(tra);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajadores>> GetTra(int id)
        {
            var tra = await _traService.GetT(id);
            if (tra == null)
            {
                return NotFound();
            }
            return Ok(tra);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Trabajadores>> PostTrabajadores([FromBody] Trabajadores trabajadores)
        {
            string numdoc = trabajadores.NumDoc;
            string nombre = trabajadores.Nombres;
            string apellido = trabajadores.Apellidos;
            int IdRol = trabajadores.IDRolFK;
            int IdTiD = trabajadores.IDTipoDocFK;
            var newTra = await _traService.CreateT(numdoc,nombre,apellido,IdRol,IdTiD);
            return CreatedAtAction(nameof(GetTra), new { id = newTra.IDTrabajador }, newTra);
        }
        // PUT: api/
        [HttpPut]
        public async Task<IActionResult> PutTrabajadores([FromBody] Trabajadores trabajadores)
        {
            int id = trabajadores.IDTrabajador;
            string? numdoc = trabajadores.NumDoc;
            string? nombre = trabajadores.Nombres;
            string? apellido = trabajadores.Apellidos;
            int? IdRol = trabajadores.IDRolFK;
            int? IdTiD = trabajadores.IDTipoDocFK;
            var updatedtra = await _traService.Update(id, numdoc, nombre, apellido, IdRol, IdTiD);
            if (updatedtra == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajadores(int id)
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
