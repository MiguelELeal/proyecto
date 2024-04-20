using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IlogroRepository
    {
        Task<List<Logro>> GetAll();
        Task<Logro> GetLogro(int id);
        Task<Logro> CreateLogro(string nombre);
        Task<Logro> Update(Logro logro);
        Task<Logro> Delete(int id);
    }
    public class LogroRepository : IlogroRepository
    {
        private readonly GranjaDbContext _db;
        public LogroRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<Logro> CreateLogro(string nombre)
        {
            Logro newLogro = new Logro
            {
                NombreLogro = nombre
            };
            await _db.Logros.AddAsync(newLogro);
            await _db.SaveChangesAsync();
            return newLogro;
        }

        public async Task<Logro> Delete(int id)
        {
            Logro logro = await GetLogro(id);

            return await Update(logro);
        }

        public async Task<List<Logro>> GetAll()
        {
            return await _db.Logros.ToListAsync();
        }

        public async Task<Logro> GetLogro(int id)
        {
            return await _db.Logros.FindAsync(id);
        }

        public async Task<Logro> Update(Logro logro)
        {
            _db.Logros.Update(logro);
            await _db.SaveChangesAsync();
            return logro;
        }
    }
}
