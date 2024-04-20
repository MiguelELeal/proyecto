using proyecto.Model;
using proyecto.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto.Services
{
    public interface ICultivoService
    {
        Task<List<Cultivo>> GetAll();
        Task<Cultivo> GetCultivo(int id);
        Task<Cultivo> CreateCultivo(int IdSiembra, DateOnly FechaCosE, int IdEstado, DateOnly FechaModificacion);
        Task<Cultivo> Update(int id, int? IdSiembra, DateOnly? FechaCosE, int? IdEstado, DateOnly? FechaModificacion);
        Task<Cultivo> Delete(int id);
    }
    public class CultivoService : ICultivoService
    {
        private readonly ICultivoRepository _cultivoRepository;
        public CultivoService(ICultivoRepository cultivoRepository)
        {
            _cultivoRepository = cultivoRepository;
        }
        public async Task<Cultivo> CreateCultivo(int IdSiembra, DateOnly FechaCosE, int IdEstado, DateOnly FechaModificacion)
        {
            return await _cultivoRepository.CreateCultivo(IdSiembra,FechaCosE,IdEstado,FechaModificacion);
        }

        public async Task<Cultivo> Delete(int id)
        {
            return await _cultivoRepository.Delete(id);
        }

        public Task<List<Cultivo>> GetAll()
        {
            return _cultivoRepository.GetAll();
        }

        public Task<Cultivo> GetCultivo(int id)
        {
            return _cultivoRepository.GetCultivo(id);
        }

        public async Task<Cultivo> Update(int id, int? IdSiembra, DateOnly? FechaCosE, int? IdEstado, DateOnly? FechaModificacion)
        {
            Cultivo cultivo = await _cultivoRepository.GetCultivo(id);
            if (cultivo == null)
            {
                return null;
            }
            else
            {
                if (IdSiembra != null)
                {
                    cultivo.IdSiembraFK = (int)IdSiembra;
                }
                if (FechaCosE != null)
                {
                    cultivo.FechaCosechaE = (DateOnly)FechaCosE;
                }
                if (IdEstado != null)
                {
                    cultivo.IdEstadoFK = (int)IdEstado;
                }
                if (FechaModificacion != null) {
                    cultivo.FechaModificacion = (DateOnly)FechaModificacion;
                }



            }
            return await _cultivoRepository.Update(cultivo);
        }
    }
}
