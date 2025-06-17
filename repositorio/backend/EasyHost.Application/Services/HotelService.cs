using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Application.DTOs.Response.HotelResponse;
using Mapster;


namespace EasyHost.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IEnumerable<Hotel> GetAll()
        {
            try
            {
                return _hotelRepository.GetAll();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar buscar no banco de dados", ex);
            }
        }

        public HotelDto GetHotelById(Guid id)
        {
              var hotel = _hotelRepository.GetHotelById(id)
                ?? throw new KeyNotFoundException("Hotel não encontrado.");

            return hotel.Adapt<HotelDto>();
        }
    }
}
