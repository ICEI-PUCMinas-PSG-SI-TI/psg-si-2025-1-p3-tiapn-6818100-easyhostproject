using EasyHost.Domain.Enums;

namespace EasyHost.Application.DTOs.Response.ReservaResponse
{
    public class ReservaDto
    {
        public Guid _id { get; set; }
        public Guid _hospedeId { get; set; }
        public Guid _quartoId { get; set; }
        public DateTime _dataEntrada { get; set; }
        public DateTime _dataSaida { get; set; }
        public StatusReserva _statusReserva { get; set; }
    }
}
