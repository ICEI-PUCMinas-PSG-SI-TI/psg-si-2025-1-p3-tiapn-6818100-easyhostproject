
namespace EasyHost.Application.DTOs.Request.ConsumoRequest
{
    public class CreateConsumoDto
    {
        public string nome { get;  set; }
        public decimal preco { get;  set; }
        public Guid hospedeId { get; set; }
        public Guid hotelId { get; set; }

    }
}
