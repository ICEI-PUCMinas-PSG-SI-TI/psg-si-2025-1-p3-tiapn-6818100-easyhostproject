using EasyHost.Domain.Entities;

namespace EasyHost.Domain.Interfaces
{
    public interface IHotelRepository
    {
       IEnumerable<Hotel> GetAll();
       Hotel? GetHotelById(Guid id);
    }
}
