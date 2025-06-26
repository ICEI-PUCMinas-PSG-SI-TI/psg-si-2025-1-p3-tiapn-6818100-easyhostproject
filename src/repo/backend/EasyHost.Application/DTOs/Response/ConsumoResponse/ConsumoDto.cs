
namespace EasyHost.Application.DTOs.Response.ConsumoResponse
{
    public class ConsumoDto
    {
        public Guid id { get;  set; }
        public string nome { get;  set; }
        public decimal preco { get;  set; }
        public Guid hospedeId { get;  set; }
    }
}
