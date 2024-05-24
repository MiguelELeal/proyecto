using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IInsumosRequeridosRepository
    {
        Task<List<InsumosRequeridos>> GetAll();
        Task<InsumosRequeridos> GetIns(int id);
        Task<InsumosRequeridos> CreateIns(int IdInsumo, int IdProcedimiento, int Cantidad);
        Task<InsumosRequeridos> Update(InsumosRequeridos ins);
        Task<InsumosRequeridos> Delete(int id);
    }
    public class InsumosRequeridoRepository : IInsumosRequeridosRepository
    {
        private readonly AgroCacao _db;
        public InsumosRequeridoRepository(AgroCacao db)
        {
            _db = db;
        }

        public async Task<InsumosRequeridos> CreateIns(int IdInsumo, int IdProcedimiento, int Cantidad)
        {
            InsumosRequeridos newInRe = new InsumosRequeridos
            {
                IDInsumoFK = IdInsumo,
                IDProcedimientoFK = IdProcedimiento,
                Cantidad = Cantidad
            };
            await _db.InsumosRequeridos.AddAsync(newInRe);
            await _db.SaveChangesAsync();
            return newInRe;
        }

        public async Task<InsumosRequeridos> Delete(int id)
        {
            InsumosRequeridos ins = await GetIns(id);

            if (ins == null)
            {
                return ins;
            }
            else
            {
                ins.status = false;
            }
            _db.Entry(ins).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return ins;
        }

        public async Task<List<InsumosRequeridos>> GetAll()
        {
            return await _db.InsumosRequeridos.Include(c=> c.Insumos).Include(c => c.Procedimento).ToListAsync();
        }

        public async Task<InsumosRequeridos> GetIns(int id)
        {
            return await _db.InsumosRequeridos.FindAsync(id);
        }

        public async Task<InsumosRequeridos> Update(InsumosRequeridos ins)
        {
            _db.InsumosRequeridos.Update(ins);
            await _db.SaveChangesAsync();
            return ins;
        }
    }
}
