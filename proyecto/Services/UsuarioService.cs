using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetU(int id);
        Task<Usuario> CreateU(string email, string contrasena, int IdRol);
        Task<Usuario> Update(int id, string? email, string? contrasena, int? IdRol);
        Task<Usuario> Delete(int id);
        Task<Usuario> LoginJ(string username, string password);
        Task<List<Usuario>> LoginA(string username, string password);

    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuRepository;
        public UsuarioService(IUsuarioRepository usuRepository)
        {
            _usuRepository = usuRepository;
        }
        public async Task<Usuario> CreateU(string email, string contrasena, int IdRol)
        {
            return await _usuRepository.CreateU(email, contrasena, IdRol);
        }

        public async Task<Usuario> Delete(int id)
        {
            return await _usuRepository.Delete(id);
        }

        public Task<List<Usuario>> GetAll()
        {
            return _usuRepository.GetAll();
        }

        public Task<Usuario> GetU(int id)
        {
            return _usuRepository.GetU(id);
        }

        public async Task<Usuario> Update(int id, string? email, string? contrasena, int? IdRol)
        {
            Usuario usu = await _usuRepository.GetU(id);
            if (usu == null)
            {
                return null;
            }
            else
            {
                if (email != null)
                {
                    usu.email = email;
                }
                if (contrasena != null)
                {
                    usu.contrasena = contrasena;
                }
                if (IdRol != null)
                {
                    usu.IdRolFK = (int)IdRol;
                }


            }
            return await _usuRepository.Update(usu);
        }
        public async Task<Usuario> LoginJ(string userName, string password)
        {
            return await _usuRepository.LoginJ(userName, password);
        }
        public Task<List<Usuario>> LoginA(string userName, string password)
        {
            return _usuRepository.LoginA(userName, password);
        }

    }
}
