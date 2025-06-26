using EasyHost.Application.DTOs.Request.ConsumoRequest;
using EasyHost.Application.DTOs.Response.ConsumoResponse;

namespace EasyHost.Application.Interfaces
{
    public interface IConsumoService
    {
        ConsumoDto CreateConsumo(CreateConsumoDto dto);
        IEnumerable<ConsumoDto> GetConsumosByHospedeId(Guid hospedeId);
        IEnumerable<Object> GetConsumosFrequencia(Guid hotelId);
        void DeleteConsumo(Guid id);
    }
}
