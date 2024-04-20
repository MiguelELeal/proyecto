using proyecto.Model;
using proyecto.Repositories;

namespace proyecto.Services
{
    public interface IInsumosService
    {
        Task<List<Insumos>> GetAll();
        Task<Insumos> GetInsumo(int id);
        Task<Insumos> CreateInsumo(string nombre, string descripcion, int stock);
        Task<Insumos> Update(int id,string? nombre, string? descripcion, int? stock);
        Task<Insumos> Delete(int id);
    }
    public class InsumosService : IInsumosService
    {
        private readonly IInsumosRepository _insumoRepository;
        public InsumosService(IInsumosRepository insumoRepository)
        {
            _insumoRepository = insumoRepository;
        }
        public async Task<Insumos> CreateInsumo(string nombre, string descripcion, int stock)
        {
            return await _insumoRepository.CreateInsumo(nombre,descripcion,stock);
        }

        public async Task<Insumos> Delete(int id)
        {
            return await _insumoRepository.Delete(id);
        }

        public Task<List<Insumos>> GetAll()
        {
            return _insumoRepository.GetAll();
        }

        public Task<Insumos> GetInsumo(int id)
        {
            return _insumoRepository.GetInsumo(id);
        }

        public async Task<Insumos> Update(int id, string? nombre, string? descripcion, int? stock)
        {
            Insumos insumos = await _insumoRepository.GetInsumo(id);
            if (insumos == null)
            {
                return null;
            }
            else
            {
                if (nombre != null)
                {
                    insumos.NombreInsumo = nombre;
                }
                if (descripcion != null)
                {
                    insumos.Descripcion = descripcion;
                }
                if (stock != null) { 
                    insumos.stock = (int)stock;
                }


            }
            return await _insumoRepository.Update(insumos);
        }
    }
}
