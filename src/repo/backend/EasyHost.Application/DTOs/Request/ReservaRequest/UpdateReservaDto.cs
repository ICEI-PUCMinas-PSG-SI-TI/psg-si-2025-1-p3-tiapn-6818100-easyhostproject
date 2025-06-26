using EasyHost.Domain.Enums;

namespace EasyHost.Application.DTOs.Request.ReservaRequest
{
    public class UpdateReservaDto
    {
        public Guid _id { get; set; }
        public StatusReserva _statusReserva { get; set; }
    }
}
