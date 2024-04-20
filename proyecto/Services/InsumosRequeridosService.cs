using proyecto.Model;
using proyecto.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto.Services
{
    public interface IInsumosRequeridosService
    {
        Task<List<InsumosRequeridos>> GetAll();
        Task<InsumosRequeridos> GetIns(int id);
        Task<InsumosRequeridos> CreateIns(int IdInsumo, int IdProcedimiento, int Cantidad);
        Task<InsumosRequeridos> Update(int id,int? IdInsumo, int? IdProcedimiento, int? Cantidad);
        Task<InsumosRequeridos> Delete(int id);
    }
    public class InsumosRequeridosService : IInsumosRequeridosService
    {
        private readonly IInsumosRequeridosRepository _inReRepository;
        public InsumosRequeridosService(IInsumosRequeridosRepository inReRepository)
        {
            _inReRepository = inReRepository;
        }
        public async Task<InsumosRequeridos> CreateIns(int IdInsumo, int IdProcedimiento, int Cantidad)
        {
            return await _inReRepository.CreateIns(IdInsumo,IdProcedimiento,Cantidad);
        }

        public async Task<InsumosRequeridos> Delete(int id)
        {
            return await _inReRepository.Delete(id);
        }

        public Task<List<InsumosRequeridos>> GetAll()
        {
            return _inReRepository.GetAll();
        }

        public Task<InsumosRequeridos> GetIns(int id)
        {
            return _inReRepository.GetIns(id);
        }

        public async Task<InsumosRequeridos> Update(int id, int? IdInsumo, int? IdProcedimiento, int? Cantidad)
        {
            InsumosRequeridos ins = await _inReRepository.GetIns(id);
            if (ins == null)
            {
                return null;
            }
            else
            {
                if (IdInsumo != null)
                {
                    ins.IDInsumoFK = (int)IdInsumo;
                }
                if (IdProcedimiento != null)
                {
                    ins.IDProcedimientoFK = (int)IdProcedimiento;
                }
                if (Cantidad != null)
                {
                    ins.Cantidad = (int)Cantidad;
                }


            }
            return await _inReRepository.Update(ins);
        }
    }
}
