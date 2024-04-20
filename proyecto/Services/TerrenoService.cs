using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ITerrenoService
    {
        Task<List<Terreno>> GetAll();
        Task<Terreno> GetTe(int id);
        Task<Terreno> CreateTe(string nombre, float area);
        Task<Terreno> Update(int id,string? nombre, float? area);
        Task<Terreno> Delete(int id);
    }
    public class TerrenoService : ITerrenoService
    {
        private readonly ITerrenoRepository _teRepository;
        public TerrenoService(ITerrenoRepository teRepository)
        {
            _teRepository = teRepository;
        }
        public async Task<Terreno> CreateTe(string nombre, float area)
        {
            return await _teRepository.CreateTe(nombre, area);
        }

        public async Task<Terreno> Delete(int id)
        {
            return await _teRepository.Delete(id);
        }

        public Task<List<Terreno>> GetAll()
        {
            return _teRepository.GetAll();
        }

        public Task<Terreno> GetTe(int id)
        {
            return _teRepository.GetTe(id);
        }

        public async Task<Terreno> Update(int id, string? nombre, float? area)
        {
            Terreno te = await _teRepository.GetTe(id);
            if (te == null)
            {
                return null;
            }
            else
            {
                if (nombre != null)
                {
                    te.Nombre = nombre;
                }
                if (area != null)
                {
                    te.Area = (float)area;
                }


            }
            return await _teRepository.Update(te);
        }
    }
    
    
}
