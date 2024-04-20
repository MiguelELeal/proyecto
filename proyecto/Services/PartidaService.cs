using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IPartidaService
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int id);
        Task<Partida> CreatePartida(int IdUsuario, DateOnly fechaInicio);
        Task<Partida> Update(int id,int? IdUsuario, DateOnly? fechaInicio);
        Task<Partida> Delete(int id);
    }
    public class PartidaService : IPartidaService
    {
        private readonly IPartidaRepository _partidaRepository;
        public PartidaService(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }
        public async Task<Partida> CreatePartida(int IdUsuario, DateOnly fechaInicio)
        {
            return await _partidaRepository.CreatePartida(IdUsuario, fechaInicio);
        }

        public async Task<Partida> Delete(int id)
        {
            return await _partidaRepository.Delete(id);
        }

        public Task<List<Partida>> GetAll()
        {
            return _partidaRepository.GetAll();
        }

        public Task<Partida> GetPartida(int id)
        {
            return _partidaRepository.GetPartida(id);
        }

        public async Task<Partida> Update(int id, int? IdUsuario, DateOnly? fechaInicio)
        {
            Partida partida = await _partidaRepository.GetPartida(id);
            if (partida == null)
            {
                return null;
            }
            else
            {
                if (IdUsuario != null)
                {
                    partida.IDUsuarioFK = (int)IdUsuario;
                }
                
                if (fechaInicio != null)
                {
                    partida.FechaInicio = (DateOnly)fechaInicio;
                }


            }
            return await _partidaRepository.Update(partida);
        }
    }
}
