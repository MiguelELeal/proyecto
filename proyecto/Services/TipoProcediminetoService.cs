using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ITipoProcediminetoService
    {
        Task<List<TipoProcedimiento>> GetAll();
        Task<TipoProcedimiento> GetTp(int id);
        Task<TipoProcedimiento> CreateTp(string tipo);
        Task<TipoProcedimiento> Update(int id,string tipo);
        Task<TipoProcedimiento> Delete(int id);
    }
    public class TipoProcediminetoService : ITipoProcediminetoService
    {
        private readonly ITipoProcedimientRepository _tpRepository;

        public TipoProcediminetoService(ITipoProcedimientRepository tpRepository)
        {
            _tpRepository = tpRepository;
        }
        public async Task<TipoProcedimiento> CreateTp(string tipo)
        {
            return await _tpRepository.CreateTp(tipo);
        }

        public async Task<TipoProcedimiento> Delete(int id)
        {
            return await _tpRepository.Delete(id);
        }

        public Task<List<TipoProcedimiento>> GetAll()
        {
            return _tpRepository.GetAll();
        }

        public Task<TipoProcedimiento> GetTp(int id)
        {
            return _tpRepository.GetTp(id);
        }

        public async Task<TipoProcedimiento> Update(int id, string tipo)
        {
            TipoProcedimiento tp = await _tpRepository.GetTp(id);
            if (tp == null)
            {
                return null;
            }
            else
            {
                if (tipo != null)
                {
                    tp.Nombre = tipo;
                }


            }
            return await _tpRepository.Update(tp);
        }
    }
}
