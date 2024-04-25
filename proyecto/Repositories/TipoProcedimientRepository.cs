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
        private readonly AgroCacao _db;
        public TipoProcedimientRepository(AgroCacao db)
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

            if (tp == null)
            {
                return tp;
            }
            else
            {
                tp.status = false;
            }
            _db.Entry(tp).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tp;
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
