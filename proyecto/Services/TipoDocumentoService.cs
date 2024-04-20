using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ITipoDocumentoService
    {
        Task<List<TipoDocumento>> GetAll();
        Task<TipoDocumento> GetTD(int id);
        Task<TipoDocumento> CreateTD(string tipo);
        Task<TipoDocumento> Update(int id,string tipo);
        Task<TipoDocumento> Delete(int id);
    }
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tdRepository;

        public TipoDocumentoService(ITipoDocumentoRepository tdRepository)
        {
            _tdRepository = tdRepository;
        }
        public async Task<TipoDocumento> CreateTD(string tipo)
        {
            return await _tdRepository.CreateTD(tipo);
        }

        public async Task<TipoDocumento> Delete(int id)
        {
            return await _tdRepository.Delete(id);
        }

        public Task<List<TipoDocumento>> GetAll()
        {
            return _tdRepository.GetAll();
        }

        public Task<TipoDocumento> GetTD(int id)
        {
            return _tdRepository.GetTD(id);
        }

        public async Task<TipoDocumento> Update(int id, string tipo)
        {
            TipoDocumento td = await _tdRepository.GetTD(id);
            if (td == null)
            {
                return null;
            }
            else
            {
                if (tipo != null)
                {
                    td.TipoDo = tipo;
                }


            }
            return await _tdRepository.Update(td);
        }
    }
}
