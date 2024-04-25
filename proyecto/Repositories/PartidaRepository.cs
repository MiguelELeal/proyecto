using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using proyecto.Context;
using proyecto.Model;

namespace proyecto.Repositories
{
    public interface IPartidaRepository
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int id);
        Task<Partida> CreatePartida(int IdUsuario, DateOnly fechaInicio, string ubicacion, string nivel);
        Task<Partida> Update(Partida partida);
        Task<Partida> Delete(int id);
    }
    public class PartidaRepository : IPartidaRepository
    {
        private readonly AgroCacao _db;
        public PartidaRepository(AgroCacao db)
        {
            _db = db;
        }
        public async Task<Partida> CreatePartida(int IdUsuario, DateOnly fechaInicio, string ubicacion, string nivel)
        {
            Partida newPartida = new Partida
            {
                IDUsuarioFK = IdUsuario,
                FechaInicio = fechaInicio,
                Ubicacion = ubicacion,
                Nivel = nivel
            };
            await _db.Partida.AddAsync(newPartida);
            await _db.SaveChangesAsync();
            return newPartida;
        }

        public async Task<Partida> Delete(int id)
        {
            Partida partida = await GetPartida(id);

            if (partida == null)
            {
                return partida;
            }
            else
            {
                partida.status = false;
            }
            _db.Entry(partida).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return partida;
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
