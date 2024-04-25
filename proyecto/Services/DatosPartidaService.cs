using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IDatosPartidaService
    {
        Task<List<DatosPartida>> GetAll();
        Task<DatosPartida> GetDp(int id);
        Task<DatosPartida> CreateDp(int IdPartida, int IdProcedimiento);
        Task<DatosPartida> Update(int id, int? IdPartida, int? IdProcedimiento);
        Task<DatosPartida> Delete(int id);
    }
    public class DatosPartidaService : IDatosPartidaService
    {
        private readonly IDatosPartidaRepository _datosRepository;
        public DatosPartidaService(IDatosPartidaRepository datosRepository)
        {
            _datosRepository = datosRepository;
        }
        public async Task<DatosPartida> CreateDp(int IdPartida, int IdProcedimiento)
        {
            return await _datosRepository.CreateDp(IdPartida, IdProcedimiento);
        }

        public async Task<DatosPartida> Delete(int id)
        {
            return await _datosRepository.Delete(id);
        }

        public Task<List<DatosPartida>> GetAll()
        {
            return _datosRepository.GetAll();
        }

        public Task<DatosPartida> GetDp(int id)
        {
            return _datosRepository.GetDp(id);
        }

        public async Task<DatosPartida> Update(int id, int? IdPartida, int? IdProcedimiento)
        {
            DatosPartida datos = await _datosRepository.GetDp(id);
            if (datos == null)
            {
                return null;
            }
            else
            {
                if (IdPartida != null)
                {
                    datos.IdPartidaFk = (int)IdPartida;
                }
                if (IdProcedimiento != null)
                {
                    datos.IdProcedimientoFk = (int)IdProcedimiento;
                }



            }
            return await _datosRepository.Update(datos);
        }
    }
}
