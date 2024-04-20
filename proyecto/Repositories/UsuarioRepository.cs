using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;
using System.Net;

namespace proyecto.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetU(int id);
        Task<Usuario> CreateU(string email, string contrasena, int IdRol);
        Task<Usuario> Update(Usuario usu);
        Task<Usuario> Delete(int id);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GranjaDbContext _db;
        public UsuarioRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<Usuario> CreateU(string email, string contrasena, int IdRol)
        {
            Usuario newUsu = new Usuario
            {
                email = email,
                contrasena = contrasena,
                IdRolFK = IdRol
            };
            await _db.Usuarios.AddAsync(newUsu);
            await _db.SaveChangesAsync();
            return newUsu;
        }

        public async Task<Usuario> Delete(int id)
        {
            Usuario usu = await GetU(id);

            return await Update(usu);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetU(int id)
        {
            return await _db.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> Update(Usuario usu)
        {
            _db.Usuarios.Update(usu);
            await _db.SaveChangesAsync();
            return usu;
        }
    }
}
