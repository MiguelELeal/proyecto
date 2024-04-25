using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto.Repositories
{
    public interface IEstadoCultivoRepository {
        Task<List<EstadoCultivo>> GetAll();
        Task<EstadoCultivo> GetEsta(int id);
        Task<EstadoCultivo> CreateEsta(string nombre);
        Task<EstadoCultivo> Update(EstadoCultivo esta);
        Task<EstadoCultivo> Delete(int id);
    }
    public class EstadoCultivoRepository : IEstadoCultivoRepository
    {
        private readonly AgroCacao _db;
        public EstadoCultivoRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<EstadoCultivo> CreateEsta(string nombre)
        {
            EstadoCultivo newEsta = new EstadoCultivo
            {
                NombreEstado = nombre
            };
            await _db.EstadoCultivos.AddAsync(newEsta);
            await _db.SaveChangesAsync();
            return newEsta;
        }

        public async Task<EstadoCultivo> Delete(int id)
        {
            EstadoCultivo esta = await GetEsta(id);

            if (esta == null)
            {
                return esta;
            }
            else
            {
                esta.status = false;
            }
            _db.Entry(esta).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return esta;
        }

        public async Task<List<EstadoCultivo>> GetAll()
        {
            return await _db.EstadoCultivos.ToListAsync();
        }

        public async Task<EstadoCultivo> GetEsta(int id)
        {
            return await _db.EstadoCultivos.FindAsync(id);
        }

        public async Task<EstadoCultivo> Update(EstadoCultivo esta)
        {
            _db.EstadoCultivos.Update(esta);
            await _db.SaveChangesAsync();
            return esta;
        }
    }
}
