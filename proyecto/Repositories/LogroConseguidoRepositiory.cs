using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto.Repositories
{
    public interface ILogroConseguidoRepositiory
    {
        Task<List<LogroConseguido>> GetAll();
        Task<LogroConseguido> GetLoCo(int id);
        Task<LogroConseguido> CreateLoCo(int IdPartida, int IdLogro,DateOnly fechaLogro);
        Task<LogroConseguido> Update(LogroConseguido logroco);
        Task<LogroConseguido> Delete(int id);
    }
    public class LogroConseguidoRepositiory : ILogroConseguidoRepositiory
    {
        private readonly AgroCacao _db;
        public LogroConseguidoRepositiory(AgroCacao db)
        {
            _db = db;
        }
        public async Task<LogroConseguido> CreateLoCo(int IdPartida, int IdLogro, DateOnly fechaLogro)
        {
            LogroConseguido newLoco = new LogroConseguido
            {
                IDPartidaFK = IdPartida,
                IDLogroFK = IdLogro,
                FechaLogro = fechaLogro
            };
            await _db.LogrosConseguidos.AddAsync(newLoco);
            await _db.SaveChangesAsync();
            return newLoco;
        }

        public async Task<LogroConseguido> Delete(int id)
        {
            LogroConseguido loco = await GetLoCo(id);

            if (loco == null)
            {
                return loco;
            }
            else
            {
                loco.status = false;
            }
            _db.Entry(loco).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return loco;
        }

        public async Task<List<LogroConseguido>> GetAll()
        {
            return await _db.LogrosConseguidos.Include(c=> c.Partida).Include(c => c.Logro).ToListAsync();
        }

        public async Task<LogroConseguido> GetLoCo(int id)
        {
            return await _db.LogrosConseguidos.FindAsync(id);
        }

        public async Task<LogroConseguido> Update(LogroConseguido logroco)
        {
            _db.LogrosConseguidos.Update(logroco);
            await _db.SaveChangesAsync();
            return logroco;
        }
    }
}
