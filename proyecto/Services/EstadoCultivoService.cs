using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IEStadoCultivoService
    {
        Task<List<EstadoCultivo>> GetAll();
        Task<EstadoCultivo> GetEsta(int id);
        Task<EstadoCultivo> CreateEsta(string nombre);
        Task<EstadoCultivo> Update(int id, string? nombre);
        Task<EstadoCultivo> Delete(int id);
    }
    public class EstadoCultivoService : IEStadoCultivoService
    {
        private readonly IEstadoCultivoRepository _estadoRepository;
        public EstadoCultivoService(IEstadoCultivoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
        public async Task<EstadoCultivo> CreateEsta(string nombre)
        {
            return await _estadoRepository.CreateEsta(nombre);
        }

        public async Task<EstadoCultivo> Delete(int id)
        {
            return await _estadoRepository.Delete(id);
        }

        public Task<List<EstadoCultivo>> GetAll()
        {
            return _estadoRepository.GetAll();
        }

        public Task<EstadoCultivo> GetEsta(int id)
        {
            return _estadoRepository.GetEsta(id);
        }

        public async Task<EstadoCultivo> Update(int id, string? nombre)
        {
            EstadoCultivo esta = await _estadoRepository.GetEsta(id);
            if (esta == null)
            {
                return null;
            }
            else
            {
                if (nombre != null)
                {
                    esta.NombreEstado = nombre;
                }


            }
            return await _estadoRepository.Update(esta);
        }
    }
}
