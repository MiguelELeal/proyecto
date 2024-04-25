using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface ITerrenoRepository
    {
        Task<List<Terreno>> GetAll();
        Task<Terreno> GetTe(int id);
        Task<Terreno> CreateTe(string nombre, float area);
        Task<Terreno> Update(Terreno terreno);
        Task<Terreno> Delete(int id);
    }
    public class TerrenoRepository : ITerrenoRepository
    {
        private readonly AgroCacao _db;
        public TerrenoRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<Terreno> CreateTe(string nombre, float area)
        {
            Terreno newTe = new Terreno
            {
                Nombre = nombre,
                Area = area
            };
            await _db.Terrenos.AddAsync(newTe);
            await _db.SaveChangesAsync();
            return newTe;
        }

        public async Task<Terreno> Delete(int id)
        {
            Terreno terreno = await GetTe(id);

            if (terreno == null)
            {
                return terreno;
            }
            else
            {
                terreno.status = false;
            }
            _db.Entry(terreno).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return terreno;
        }

        public async Task<List<Terreno>> GetAll()
        {
            return await _db.Terrenos.ToListAsync();
        }

        public async Task<Terreno> GetTe(int id)
        {
            return await _db.Terrenos.FindAsync(id);
        }

        public async Task<Terreno> Update(Terreno terreno)
        {
            _db.Terrenos.Update(terreno);
            await _db.SaveChangesAsync();
            return terreno;
        }
    }
}
