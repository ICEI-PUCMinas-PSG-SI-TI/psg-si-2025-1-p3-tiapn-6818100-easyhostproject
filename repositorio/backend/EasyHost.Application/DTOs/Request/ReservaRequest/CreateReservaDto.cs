
namespace EasyHost.Application.DTOs.Request.ReservaRequest
{
    public class CreateReservaDto
    {
        public Guid _hospedeId { get; set; }
        public Guid _hotelId { get; set; }
        public Guid _quartoId { get; set; }
        public DateTime _dataEntrada { get; set; }
        public DateTime _dataSaida { get; set; }
    }
}