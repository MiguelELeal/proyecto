using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IDatosPartidaRepository
    {
        Task<List<DatosPartida>> GetAll();
        Task<DatosPartida> GetDp(int id);
        Task<DatosPartida> CreateDp(int IdPartida, int IdProcedimiento);
        Task<DatosPartida> Update(DatosPartida datos);
        Task<DatosPartida> Delete(int id);
    }
    public class DatosPartidaRepository : IDatosPartidaRepository
    {
        private readonly AgroCacao _db;
        public DatosPartidaRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<DatosPartida> CreateDp(int IdPartida, int IdProcedimiento)
        {
            DatosPartida newDatos = new DatosPartida
            {
                IdPartidaFk = IdPartida,
                IdProcedimientoFk = IdProcedimiento
            };
            await _db.DatosPartidas.AddAsync(newDatos);
            await _db.SaveChangesAsync();
            return newDatos;
        }

        public async Task<DatosPartida> Delete(int id)
        {
            DatosPartida datos = await GetDp(id);
            if (datos == null)
            {
                return datos;
            }
            else
            {
                datos.status = false;
            }
            _db.Entry(datos).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return datos;
        }

        public async Task<List<DatosPartida>> GetAll()
        {
            return await _db.DatosPartidas.ToListAsync();
        }

        public async Task<DatosPartida> GetDp(int id)
        {
            return await _db.DatosPartidas.FindAsync(id);
        }

        public async Task<DatosPartida> Update(DatosPartida datos)
        {
            _db.DatosPartidas.Update(datos);
            await _db.SaveChangesAsync();
            return datos;
        }
    }
}
