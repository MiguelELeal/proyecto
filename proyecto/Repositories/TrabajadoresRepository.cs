using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface ITrabajadoresRepository
    {
        Task<List<Trabajadores>> GetAll();
        Task<Trabajadores> GetT(int id);
        Task<Trabajadores> CreateT(string numdoc,string nombre,string apellido,int IdRol,int IdTiD);
        Task<Trabajadores> Update(Trabajadores tra);
        Task<Trabajadores> Delete(int id);
    }
    public class TrabajadoresRepository : ITrabajadoresRepository
    {
        private readonly AgroCacao _db;
        public TrabajadoresRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<Trabajadores> CreateT(string numdoc, string nombre, string apellido, int IdRol, int IdTiD)
        {
            Trabajadores newTra = new Trabajadores
            {
                NumDoc = numdoc,
                Nombres = nombre,
                Apellidos = apellido,
                IDRolFK = IdRol,
                IDTipoDocFK = IdTiD
            };
            await _db.Trabajadores.AddAsync(newTra);
            await _db.SaveChangesAsync();
            return newTra;
        }

        public async Task<Trabajadores> Delete(int id)
        {
            Trabajadores tra = await GetT(id);

            if (tra == null)
            {
                return tra;
            }
            else
            {
                tra.status = false;
            }
            _db.Entry(tra).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tra;
        }

        public async Task<List<Trabajadores>> GetAll()
        {
            return await _db.Trabajadores.ToListAsync();
        }

        public async Task<Trabajadores> GetT(int id)
        {
            return await _db.Trabajadores.FindAsync(id);
        }

        public async Task<Trabajadores> Update(Trabajadores tra)
        {
            _db.Trabajadores.Update(tra);
            await _db.SaveChangesAsync();
            return tra;
        }
    }
}
