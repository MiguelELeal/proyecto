using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface ISiembraRepository
    {
        Task<List<Siembra>> GetAll();
        Task<Siembra> GetSie(int id);
        Task<Siembra> CreateSie(DateOnly fechaSie, float Area, int IdTe);
        Task<Siembra> Update(Siembra siembra);
        Task<Siembra> Delete(int id);
    }

    public class SiembraRepository : ISiembraRepository
    {
        private readonly GranjaDbContext _db;
        public SiembraRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<Siembra> CreateSie(DateOnly fechaSie, float Area, int IdTe)
        {
            Siembra newSie = new Siembra
            {
                FechaSiembra = fechaSie,
                AreaTotalS = Area,
                IDTerrenoFK = IdTe
            };
            await _db.Siembras.AddAsync(newSie);
            await _db.SaveChangesAsync();
            return newSie;

        }

        public async Task<Siembra> Delete(int id)
        {
            Siembra siembra = await GetSie(id);

            return await Update(siembra);
        }

        public async Task<List<Siembra>> GetAll()
        {
            return await _db.Siembras.ToListAsync();
        }

        public async Task<Siembra> GetSie(int id)
        {
            return await _db.Siembras.FindAsync(id);
        }

        public async Task<Siembra> Update(Siembra siembra)
        {
            _db.Siembras.Update(siembra);
            await _db.SaveChangesAsync();
            return siembra;
        }
    }
}
