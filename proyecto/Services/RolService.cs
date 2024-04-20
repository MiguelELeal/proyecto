using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IRolService
    {
        Task<List<Rol>> GetAll();
        Task<Rol> GetRol(int id);
        Task<Rol> CreateRol(string tipo);
        Task<Rol> Update(int id, string? tipo);
        Task<Rol> Delete(int id);
    }
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        public async Task<Rol> CreateRol(string tipo)
        {
            return await _rolRepository.CreateRol(tipo);
        }

        public async Task<Rol> Delete(int id)
        {
            return await _rolRepository.Delete(id);
        }

        public Task<List<Rol>> GetAll()
        {
            return _rolRepository.GetAll();
        }

        public Task<Rol> GetRol(int id)
        {
            return _rolRepository.GetRol(id);
        }

        public async Task<Rol> Update(int idRol, string? tipo)
        {
            Rol rol = await _rolRepository.GetRol(idRol);
            if (rol == null)
            {
                return null;
            }
            else
            {
                if (tipo != null)
                {
                    rol.TipoRol = tipo;
                }

                
            }
            return await _rolRepository.Update(rol);


        }
    }
}
