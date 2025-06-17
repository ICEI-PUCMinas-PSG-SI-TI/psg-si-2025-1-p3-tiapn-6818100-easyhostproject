using EasyHost.Application.DTOs.Request.HospedeRequest;
using EasyHost.Application.DTOs.Response.HospedeResponse;

namespace EasyHost.Application.Interfaces
{
    public interface IHospedeService
    {
        HospedeDto CreateHospede(CreateHospedeDto dto);
        IEnumerable<HospedeDto> GetAllHospedes(Guid hotelId);
        HospedeDto GetHospedeById(Guid id);
        HospedeDto GetHospedeByCpf(string cpf);
        void DeleteHospede(Guid id);
        decimal GetValorTotalConsumo(Guid idHospede);
    }
}
