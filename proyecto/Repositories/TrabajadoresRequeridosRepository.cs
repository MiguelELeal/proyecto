using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;
using System.Net;

namespace proyecto.Repositories
{
    public interface ITrabajadoresRequeridosRepository
    {
        Task<List<TrabajadoresRequeridos>> GetAll();
        Task<TrabajadoresRequeridos> GetTr(int id);
        Task<TrabajadoresRequeridos> CreateTr(int IdTrabador, int IdProcedimiento);
        Task<TrabajadoresRequeridos> Update(TrabajadoresRequeridos trar);
        Task<TrabajadoresRequeridos> Delete(int id);
    }
    public class TrabajadoresRequeridosRepository : ITrabajadoresRequeridosRepository
    {
        private readonly GranjaDbContext _db;
        public TrabajadoresRequeridosRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<TrabajadoresRequeridos> CreateTr(int IdTrabador, int IdProcedimiento)
        {
            TrabajadoresRequeridos newTrar = new TrabajadoresRequeridos
            {
                IDTrabjadorFK = IdTrabador,
                IDProcedimientoFK = IdProcedimiento
            };
            await _db.TrabajadoresRequeridos.AddAsync(newTrar);
            await _db.SaveChangesAsync();
            return newTrar;
        }

        public async Task<TrabajadoresRequeridos> Delete(int id)
        {
            TrabajadoresRequeridos trar = await GetTr(id);

            return await Update(trar);
        }

        public async Task<List<TrabajadoresRequeridos>> GetAll()
        {
            return await _db.TrabajadoresRequeridos.ToListAsync();
        }

        public async Task<TrabajadoresRequeridos> GetTr(int id)
        {
            return await _db.TrabajadoresRequeridos.FindAsync(id);
        }

        public async Task<TrabajadoresRequeridos> Update(TrabajadoresRequeridos trar)
        {
            _db.TrabajadoresRequeridos.Update(trar);
            await _db.SaveChangesAsync();
            return trar;
        }
    }
}
