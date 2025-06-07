using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;


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
    }
}
