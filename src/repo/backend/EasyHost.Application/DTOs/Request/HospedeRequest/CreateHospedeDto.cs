
namespace EasyHost.Application.DTOs.Request.HospedeRequest
{
    public class CreateHospedeDto
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public Guid hotelId { get; set; }
    }
}
