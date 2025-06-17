using EasyHost.Application.DTOs.Request.ReservaRequest;
using EasyHost.Application.DTOs.Response.ReservaResponse;

namespace EasyHost.Application.Interfaces
{
    public interface IReservaService
    {
        ReservaDto CadastrarReserva(CreateReservaDto dto);
        IEnumerable<ReservaDto> GetAllReservas(Guid hotelId);
        ReservaDto GetReservaPorId(Guid id);
        void AlterarReserva(UpdateReservaDto dto);
        void CancelarReserva(Guid id);
        decimal CalcularPrecoReserva(Guid id);
        double GetTempoMediaReserva(Guid hotelId);
    }
}
