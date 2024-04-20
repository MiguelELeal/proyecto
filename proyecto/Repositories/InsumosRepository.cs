using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IInsumosRepository
    {
        Task<List<Insumos>> GetAll();
        Task<Insumos> GetInsumo(int id);
        Task<Insumos> CreateInsumo(string nombre, string descripcion,int stock);
        Task<Insumos> Update(Insumos insumo);
        Task<Insumos> Delete(int id);
    }
    public class InsumosRepository : IInsumosRepository
    {
        private readonly GranjaDbContext _db;
        public InsumosRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<Insumos> CreateInsumo(string nombre, string descripcion, int stock)
        {
            Insumos newInsumos = new Insumos
            {
                 NombreInsumo= nombre,
                 Descripcion = descripcion,
                 stock=stock

            };
            await _db.Insumos.AddAsync(newInsumos);
            await _db.SaveChangesAsync();
            return newInsumos;

        }

        public async Task<Insumos> Delete(int id)
        {
            Insumos insumos = await GetInsumo(id);
            
            return await Update(insumos);
        }

        public async Task<Insumos> GetInsumo(int id)
        {
            return await _db.Insumos.FindAsync(id);
        }

        public async Task<List<Insumos>> GetAll()
        {
            return await _db.Insumos.ToListAsync();
        }

        public async Task<Insumos> Update(Insumos insumo)
        {
            _db.Insumos.Update(insumo);
            await _db.SaveChangesAsync();
            return insumo;
        }
    }
}
