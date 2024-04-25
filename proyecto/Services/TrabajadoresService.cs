using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ITrabajadoresService
    {
        Task<List<Trabajadores>> GetAll();
        Task<Trabajadores> GetT(int id);
        Task<Trabajadores> CreateT(string numdoc, string nombre, string apellido, int IdRol, int IdTiD);
        Task<Trabajadores> Update(int id, string? numdoc, string? nombre, string? apellido, int? IdRol, int? IdTiD);
        Task<Trabajadores> Delete(int id);
    }
    public class TrabajadoresService : ITrabajadoresService
    {
        private readonly ITrabajadoresRepository _traRepository;

        public TrabajadoresService(ITrabajadoresRepository traRepository)
        {
            _traRepository = traRepository;
        }
        public async Task<Trabajadores> CreateT(string numdoc, string nombre, string apellido, int IdRol, int IdTiD)
        {
            return await _traRepository.CreateT(numdoc,nombre,apellido,IdRol,IdTiD);
        }

        public async Task<Trabajadores> Delete(int id)
        {
            return await _traRepository.Delete(id);
        }

        public Task<List<Trabajadores>> GetAll()
        {
            return _traRepository.GetAll();
        }

        public Task<Trabajadores> GetT(int id)
        {
            return _traRepository.GetT(id);
        }

        public async Task<Trabajadores> Update(int id, string? numdoc, string? nombre, string? apellido, int? IdRol, int? IdTiD)
        {
            Trabajadores tra = await _traRepository.GetT(id);
            if (tra == null)
            {
                return null;
            }
            else
            {
                if (numdoc != null)
                {
                    tra.NumDoc = numdoc;
                }
                if (nombre != null)
                {

                }
                if (apellido != null)
                {
                    tra.Apellidos = apellido;
                }
                if (IdRol != null)
                {
                    tra.IDRolFK = (int)IdRol;
                }
                if (IdTiD != null)
                {
                    tra.IDTipoDocFK = (int)IdTiD;
                }

            }
            return await _traRepository.Update(tra);
        }
    }
}
