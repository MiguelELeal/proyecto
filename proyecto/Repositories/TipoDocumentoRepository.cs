using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface ITipoDocumentoRepository
    {
        Task<List<TipoDocumento>> GetAll();
        Task<TipoDocumento> GetTD(int id);
        Task<TipoDocumento> CreateTD(string tipo);
        Task<TipoDocumento> Update(TipoDocumento td);
        Task<TipoDocumento> Delete(int id);
    }
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly GranjaDbContext _db;
        public TipoDocumentoRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<TipoDocumento> CreateTD(string tipo)
        {
            TipoDocumento newTD = new TipoDocumento
            {
                TipoDo = tipo
            };
            await _db.TipoDocumentos.AddAsync(newTD);
            await _db.SaveChangesAsync();
            return newTD;
        }

        public async Task<TipoDocumento> Delete(int id)
        {
            TipoDocumento td = await GetTD(id);
            
            return await Update(td);
        }

        public async Task<List<TipoDocumento>> GetAll()
        {
            return await _db.TipoDocumentos.ToListAsync();
        }

        public async Task<TipoDocumento> GetTD(int id)
        {
            return await _db.TipoDocumentos.FindAsync(id);
        }

        public async Task<TipoDocumento> Update(TipoDocumento td)
        {
            _db.TipoDocumentos.Update(td);
            await _db.SaveChangesAsync();
            return td;
        }
    }
}
