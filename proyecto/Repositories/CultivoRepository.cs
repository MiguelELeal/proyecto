using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto.Repositories
{
    public interface ICultivoRepository
    {
        Task<List<Cultivo>> GetAll();
        Task<Cultivo> GetCultivo(int id);
        Task<Cultivo> CreateCultivo(int IdSiembra, DateOnly FechaCosE,int IdEstado,DateOnly FechaModificacion);
        Task<Cultivo> Update(Cultivo cultivo);
        Task<Cultivo> Delete(int id);
    }
    public class CultivoRepository : ICultivoRepository
    {
        private readonly AgroCacao _db;
        public CultivoRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<Cultivo> CreateCultivo(int IdSiembra, DateOnly FechaCosE, int IdEstado, DateOnly FechaModificacion)
        {
            Cultivo newCultivo = new Cultivo
            {
                IdSiembraFK = IdSiembra,
                FechaCosechaE = FechaCosE,
                IdEstadoFK = IdEstado,
                FechaModificacion = FechaModificacion
            };
            await _db.Cultivos.AddAsync(newCultivo);
            await _db.SaveChangesAsync();
            return newCultivo;
        }

        public async Task<Cultivo> Delete(int id)
        {
            Cultivo cultivo = await GetCultivo(id);

            if (cultivo == null)
            {
                return cultivo;
            }
            else
            {
                cultivo.status = false;
            }
            _db.Entry(cultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cultivo;
        }

        public async Task<List<Cultivo>> GetAll()
        {
            return await _db.Cultivos.ToListAsync();
        }

        public async Task<Cultivo> GetCultivo(int id)
        {
            return await _db.Cultivos.FindAsync(id);
        }

        public async Task<Cultivo> Update(Cultivo cultivo)
        {
            _db.Cultivos.Update(cultivo);
            await _db.SaveChangesAsync();
            return cultivo;
        }
    }
}
