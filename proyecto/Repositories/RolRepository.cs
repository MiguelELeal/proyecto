using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAll();
        Task<Rol> GetRol(int id);
        Task<Rol> CreateRol(string tipo);
        Task<Rol> Update(Rol rol);
        Task<Rol> Delete(int id);

    }
    public class RolRepository : IRolRepository
    {
        private readonly GranjaDbContext _db;
        public RolRepository(GranjaDbContext db)
        {
            _db = db;
        }
     

        public async Task<List<Rol>> GetAll()
        {
            return await _db.Roles.ToListAsync();
        }

        public async Task<Rol> GetRol(int id)
        {

            return await _db.Roles.FindAsync(id);

        }
        public async Task<Rol> CreateRol(string tipo)
        {
            Rol newRol = new Rol { 
                TipoRol = tipo 
            };
            await _db.Roles.AddAsync(newRol);
            await _db.SaveChangesAsync();
            return newRol;

        }

        public async Task<Rol> Update(Rol rol)
        {
            _db.Roles.Update(rol);
            await _db.SaveChangesAsync();
            return rol;
        }
        public async Task<Rol> Delete(int id)
        {
            Rol rol = await GetRol(id);
            if (rol == null)
            {
                return null;
            }
            else
            {
                rol.status = false;
            }
            return await Update(rol);
        }
    }
}
