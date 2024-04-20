using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ITrabajadoresRequeridosService
    {
        Task<List<TrabajadoresRequeridos>> GetAll();
        Task<TrabajadoresRequeridos> GetTr(int id);
        Task<TrabajadoresRequeridos> CreateTr(int IdTrabador, int IdProcedimiento);
        Task<TrabajadoresRequeridos> Update(int id, int? IdTrabador, int? IdProcedimiento);
        Task<TrabajadoresRequeridos> Delete(int id);
    }
    public class TrabajadoresRequeridosService : ITrabajadoresRequeridosService
    {
        private readonly ITrabajadoresRequeridosRepository _trarRepository;
        public TrabajadoresRequeridosService(ITrabajadoresRequeridosRepository trarRepository)
        {
            _trarRepository = trarRepository;
        }
        public async Task<TrabajadoresRequeridos> CreateTr(int IdTrabador, int IdProcedimiento)
        {
            return await _trarRepository.CreateTr(IdTrabador, IdProcedimiento);
        }

        public async Task<TrabajadoresRequeridos> Delete(int id)
        {
            return await _trarRepository.Delete(id);
        }

        public Task<List<TrabajadoresRequeridos>> GetAll()
        {
            return _trarRepository.GetAll();
        }

        public Task<TrabajadoresRequeridos> GetTr(int id)
        {
            return _trarRepository.GetTr(id);
        }

        public async Task<TrabajadoresRequeridos> Update(int id, int? IdTrabador, int? IdProcedimiento)
        {
            TrabajadoresRequeridos trae = await _trarRepository.GetTr(id);
            if (trae == null)
            {
                return null;
            }
            else
            {
                if (IdTrabador != null)
                {
                    trae.IDTrabjadorFK = (int)IdTrabador;
                }
                if (IdProcedimiento != null)
                {
                    trae.IDProcedimientoFK = (int)IdProcedimiento;
                }
                


            }
            return await _trarRepository.Update(trae);
        }
    }
}
