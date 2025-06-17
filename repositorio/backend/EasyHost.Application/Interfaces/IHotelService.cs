using EasyHost.Domain.Entities;
using EasyHost.Application.DTOs.Response.HotelResponse;

namespace EasyHost.Application.Interfaces
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAll();
        HotelDto GetHotelById(Guid id);
    }
}
