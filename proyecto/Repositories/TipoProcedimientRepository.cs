using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface ITipoProcedimientRepository
    {
        Task<List<TipoProcedimiento>> GetAll();
        Task<TipoProcedimiento> GetTp(int id);
        Task<TipoProcedimiento> CreateTp(string tipo);
        Task<TipoProcedimiento> Update(TipoProcedimiento tp);
        Task<TipoProcedimiento> Delete(int id);
    }
    public class TipoProcedimientRepository : ITipoProcedimientRepository
    {
        private readonly GranjaDbContext _db;
        public TipoProcedimientRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<TipoProcedimiento> CreateTp(string tipo)
        {
            TipoProcedimiento newTp = new TipoProcedimiento
            {
                Nombre = tipo
            };
            await _db.TipoProcedimientos.AddAsync(newTp);
            await _db.SaveChangesAsync();
            return newTp;
        }

        public async Task<TipoProcedimiento> Delete(int id)
        {
            TipoProcedimiento tp = await GetTp(id);

            return await Update(tp);
        }

        public async Task<List<TipoProcedimiento>> GetAll()
        {
            return await _db.TipoProcedimientos.ToListAsync();
        }

        public async Task<TipoProcedimiento> GetTp(int id)
        {
            return await _db.TipoProcedimientos.FindAsync(id);
        }

        public async Task<TipoProcedimiento> Update(TipoProcedimiento tp)
        {
            _db.TipoProcedimientos.Update(tp);
            await _db.SaveChangesAsync();
            return tp;
        }
    }
}
