using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IProcedimientoRepository
    {
        Task<List<Procedimento>> GetAll();
        Task<Procedimento> GetPro(int id);
        Task<Procedimento> CreatePro(int IdCultivo, int IdTPro, DateOnly fechaPro,string descrip);
        Task<Procedimento> Update(Procedimento pro);
        Task<Procedimento> Delete(int id);
    }
    public class ProcedimientoRepository : IProcedimientoRepository
    {
        private readonly AgroCacao _db;
        public ProcedimientoRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<Procedimento> CreatePro(int IdCultivo, int IdTPro, DateOnly fechaPro, string descrip)
        {
            Procedimento newPro = new Procedimento
            {
                IDCultivoFK = IdCultivo,
                IDTipoProcedimientoFK = IdTPro,
                FechaProcedimiento = fechaPro,
                Descripcion = descrip
            };
            await _db.Procedimentos.AddAsync(newPro);
            await _db.SaveChangesAsync();
            return newPro;
        }

        public async Task<Procedimento> Delete(int id)
        {
            Procedimento pro = await GetPro(id);

            if (pro == null)
            {
                return pro;
            }
            else
            {
                pro.status = false;
            }
            _db.Entry(pro).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return pro;
        }

        public async Task<List<Procedimento>> GetAll()
        {
            return await _db.Procedimentos.Include(c => c.Cultivo).Include(c => c.TipoProcedimiento).ToListAsync();
        }

        public async Task<Procedimento> GetPro(int id)
        {
            return await _db.Procedimentos.FindAsync(id);
        }

        public async Task<Procedimento> Update(Procedimento pro)
        {
            _db.Procedimentos.Update(pro);
            await _db.SaveChangesAsync();
            return pro;
        }
    }
}
