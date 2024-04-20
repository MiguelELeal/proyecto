using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IProcedimientoService
    {
        Task<List<Procedimento>> GetAll();
        Task<Procedimento> GetPro(int id);
        Task<Procedimento> CreatePro(int IdCultivo, int IdTPro, DateOnly fechaPro, string descrip);
        Task<Procedimento> Update(int id, int? IdCultivo, int? IdTPro, DateOnly? fechaPro, string? descrip);
        Task<Procedimento> Delete(int id);
    }
    public class ProcedimientoService : IProcedimientoService
    {
        private readonly IProcedimientoRepository _proRepository;
        public ProcedimientoService(IProcedimientoRepository proRepository)
        {
            _proRepository = proRepository;
        }
        public async Task<Procedimento> CreatePro(int IdCultivo, int IdTPro, DateOnly fechaPro, string descrip)
        {
            return await _proRepository.CreatePro(IdCultivo, IdTPro, fechaPro, descrip);
        }

        public async Task<Procedimento> Delete(int id)
        {
            return await _proRepository.Delete(id);
        }

        public Task<List<Procedimento>> GetAll()
        {
            return _proRepository.GetAll();
        }

        public Task<Procedimento> GetPro(int id)
        {
            return _proRepository.GetPro(id);
        }

        public async Task<Procedimento> Update(int id, int? IdCultivo, int? IdTPro, DateOnly? fechaPro, string? descrip)
        {
            Procedimento pro = await _proRepository.GetPro(id);
            if (pro == null)
            {
                return null;
            }
            else
            {
                if (IdCultivo != null)
                {
                    pro.IDCultivoFK = (int)IdCultivo;
                }
                if (IdTPro != null)
                {
                    pro.IDTipoProcedimientoFK = (int)IdTPro;
                }
                if (fechaPro != null)
                {
                    pro.FechaProcedimiento = (DateOnly)fechaPro;
                }
                if (descrip != null)
                {
                    pro.Descripcion = descrip;
                }


            }
            return await _proRepository.Update(pro);
        }
    }
}
