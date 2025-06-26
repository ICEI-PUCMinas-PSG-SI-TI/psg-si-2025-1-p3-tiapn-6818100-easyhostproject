using EasyHost.Domain.Entities;

namespace EasyHost.Domain.Interfaces
{
    public interface IConsumoRepository
    {
        void CreateConsumo(Consumo consumo);
        IEnumerable<Consumo>? GetConsumosByHospedeId(Guid id);
        IEnumerable<Consumo> GetAllConsumos(Guid hotelId);
        void DeletarConsumo(Guid id);
    }
}
