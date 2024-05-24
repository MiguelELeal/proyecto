using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto.Context;
using proyecto.Model;
using proyecto.Services;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usService;
        public UsuarioController(IUsuarioService usService)
        {
            _usService = usService;
        }
        [HttpGet]
        public async Task<ActionResult<Usuario>> GetAll()
        {
            var us = await _usService.GetAll();
            return Ok(us);
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUs(int id)
        {
            var us = await _usService.GetU(id);
            if (us == null)
            {
                return NotFound();
            }
            return Ok(us);
        }
        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            string email = usuario.email; 
            string contrasena = usuario.contrasena; 
            int IdRol = usuario.IdRolFK;
            var newUsu = await _usService.CreateU(email, contrasena, IdRol);
            return CreatedAtAction(nameof(GetUs), new { id = newUsu.IDUsuario }, newUsu);
        }
        // PUT: api/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id,string? email, string? contrasena, int? IdRol)
        {
            var updatedus = await _usService.Update(id, email, contrasena, IdRol);
            if (updatedus == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        // DELETE: api/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login(string userName,string password )
        {
            
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
            }

            var user = await _usService.LoginJ(userName, password);
            if (user != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        // GET: api/
        [HttpGet("{username}/{password}")]
        
        public async Task<ActionResult<Usuario>> GetIniciarSecion(string username, string password)
        {
            
            var us = await _usService.LoginA(username, password);
            if (us == null)
            {
                return NotFound();
            }
            return Ok(us);
        }

    }

}
