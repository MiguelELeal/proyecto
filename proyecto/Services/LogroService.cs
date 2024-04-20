using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ILogroService
    {
        Task<List<Logro>> GetAll();
        Task<Logro> GetLogro(int id);
        Task<Logro> CreateLogro(string nombre);
        Task<Logro> Update(int id, string? nombre);
        Task<Logro> Delete(int id);
    }
    public class LogroService : ILogroService
    {
        private readonly IlogroRepository _logroRepository;
        public LogroService(IlogroRepository logroRepository)
        {
            _logroRepository = logroRepository;
        }
        public async Task<Logro> CreateLogro(string nombre)
        {
            return await _logroRepository.CreateLogro(nombre);
        }

        public async Task<Logro> Delete(int id)
        {
            return await _logroRepository.Delete(id);
        }

        public Task<List<Logro>> GetAll()
        {
            return _logroRepository.GetAll();
        }

        public Task<Logro> GetLogro(int id)
        {
            return _logroRepository.GetLogro(id);
        }

        public async Task<Logro> Update(int id, string? nombre)
        {
            Logro logro = await _logroRepository.GetLogro(id);
            if (logro == null)
            {
                return null;
            }
            else
            {
                if (nombre != null)
                {
                    logro.NombreLogro = nombre;
                }


            }
            return await _logroRepository.Update(logro);
        }
    }
}
