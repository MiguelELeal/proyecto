using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface ISiembraService
    {
        Task<List<Siembra>> GetAll();
        Task<Siembra> GetSie(int id);
        Task<Siembra> CreateSie(DateOnly fechaSie, float Area, int IdTe);
        Task<Siembra> Update(int id,DateOnly? fechaSie, float? Area, int? IdTe);
        Task<Siembra> Delete(int id);
    }
    public class SiembraService : ISiembraService
    {
        private readonly ISiembraRepository _sieRepository;
        public SiembraService(ISiembraRepository sieRepository)
        {
            _sieRepository = sieRepository;
        }
        public async Task<Siembra> CreateSie(DateOnly fechaSie, float Area, int IdTe)
        {
            return await _sieRepository.CreateSie(fechaSie, Area, IdTe);
        }

        public async Task<Siembra> Delete(int id)
        {
            return await _sieRepository.Delete(id);
        }

        public Task<List<Siembra>> GetAll()
        {
            return _sieRepository.GetAll();
        }

        public Task<Siembra> GetSie(int id)
        {
            return _sieRepository.GetSie(id);
        }

        public async Task<Siembra> Update(int id, DateOnly? fechaSie, float? Area, int? IdTe)
        {
            Siembra sie = await _sieRepository.GetSie(id);
            if (sie == null)
            {
                return null;
            }
            else
            {
                if (fechaSie != null)
                {
                    sie.FechaSiembra = (DateOnly)fechaSie;
                }
                if (Area != null)
                {
                    sie.AreaTotalS = (float)Area;
                }
                if (IdTe != null)
                {
                    sie.IDTerrenoFK = (int)IdTe;
                }


            }
            return await _sieRepository.Update(sie);
        }
    }
}
