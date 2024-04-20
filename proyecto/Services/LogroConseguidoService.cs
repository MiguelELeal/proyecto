using proyecto.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto.Repositories
{
    public interface ILogroConseguidoService
    {
        Task<List<LogroConseguido>> GetAll();
        Task<LogroConseguido> GetLoCo(int id);
        Task<LogroConseguido> CreateLoCo(int IdPartida, int IdLogro, DateOnly fechaLogro);
        Task<LogroConseguido> Update(int id,int? IdPartida, int? IdLogro, DateOnly? fechaLogro);
        Task<LogroConseguido> Delete(int id);
    }
    public class LogroConseguidoService : ILogroConseguidoService
    {
        private readonly ILogroConseguidoRepositiory _locoRepository;
        public LogroConseguidoService(ILogroConseguidoRepositiory locoRepository)
        {
            _locoRepository = locoRepository;
        }
        public async Task<LogroConseguido> CreateLoCo(int IdPartida, int IdLogro, DateOnly fechaLogro)
        {
            return await _locoRepository.CreateLoCo(IdPartida,IdLogro,fechaLogro);
        }

        public async Task<LogroConseguido> Delete(int id)
        {
            return await _locoRepository.Delete(id);
        }

        public Task<List<LogroConseguido>> GetAll()
        {
            return _locoRepository.GetAll();
        }

        public Task<LogroConseguido> GetLoCo(int id)
        {
            return _locoRepository.GetLoCo(id);
        }

        public async Task<LogroConseguido> Update(int id, int? IdPartida, int? IdLogro, DateOnly? fechaLogro)
        {
            LogroConseguido loco = await _locoRepository.GetLoCo(id);
            if (loco == null)
            {
                return null;
            }
            else
            {
                if (IdPartida != null)
                {
                    loco.IDPartidaFK = (int)IdPartida;
                }
                if (IdLogro != null)
                {
                    loco.IDLogroFK = (int)IdLogro;
                }
                if (fechaLogro != null)
                {
                    loco.FechaLogro = (DateOnly)fechaLogro;
                }


            }
            return await _locoRepository.Update(loco);
        }
    }
}
