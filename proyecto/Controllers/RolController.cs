using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }
        [HttpGet]
        public async Task<ActionResult<Rol>> GetAll()
        {
            var rol = await _rolService.GetAll();
            return Ok(rol);
        }

        // GET: api/Rol/
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _rolService.GetRol(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }
        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(string tipo)
        {
            var newRol = await _rolService.CreateRol(tipo);
            return CreatedAtAction(nameof(GetRol), new { id = newRol.IdRol }, newRol);
        }
        // PUT: api/Rol
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, string tipo)
        {
            var updatedRol = await _rolService.Update(id, tipo);
            if (updatedRol == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/Crops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id )
        {
            var result = await _rolService.Delete(id);
            if (result==null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
