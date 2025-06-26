using EasyHost.Domain.Entities;

namespace EasyHost.Domain.Interfaces
{
    public interface IReservaRepository
    {
        void CreateReserva(Reserva reserva);
        Reserva GetReservaById(Guid id);
        IEnumerable<Reserva> GetAllReservas(Guid hotelId);
        void UpdateReserva(Reserva reserva);
        void DeleteReserva(Guid id);
    }
}
