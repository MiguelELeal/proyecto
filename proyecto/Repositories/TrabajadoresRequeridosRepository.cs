using Castle.Components.DictionaryAdapter.Xml;
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
        private readonly AgroCacao _db;
        public TrabajadoresRequeridosRepository(AgroCacao db)
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

            if (trar == null)
            {
                return trar;
            }
            else
            {
                trar.status = false;
            }
            _db.Entry(trar).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return trar;
        }

        public async Task<List<TrabajadoresRequeridos>> GetAll()
        {
            return await _db.TrabajadoresRequeridos.Include(c => c.Procedimento).Include(c=> c.Trabajadores).ToListAsync();
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
