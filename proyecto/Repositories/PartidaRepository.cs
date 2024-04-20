using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IPartidaRepository
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int id);
        Task<Partida> CreatePartida(int IdUsuario, DateOnly fechaInicio);
        Task<Partida> Update(Partida partida);
        Task<Partida> Delete(int id);
    }
    public class PartidaRepository : IPartidaRepository
    {
        private readonly GranjaDbContext _db;
        public PartidaRepository(GranjaDbContext db)
        {
            _db = db;
        }
        public async Task<Partida> CreatePartida(int IdUsuario, DateOnly fechaInicio)
        {
            Partida newPartida = new Partida
            {
                IDUsuarioFK = IdUsuario,
                FechaInicio = fechaInicio,
            };
            await _db.Partida.AddAsync(newPartida);
            await _db.SaveChangesAsync();
            return newPartida;
        }

        public async Task<Partida> Delete(int id)
        {
            Partida partida = await GetPartida(id);

            return await Update(partida);
        }

        public async Task<List<Partida>> GetAll()
        {
            return await _db.Partida.ToListAsync();
        }

        public async Task<Partida> GetPartida(int id)
        {
            return await _db.Partida.FindAsync(id);
        }

        public async Task<Partida> Update(Partida partida)
        {
            _db.Partida.Update(partida);
            await _db.SaveChangesAsync();
            return partida;
        }
    }
}
