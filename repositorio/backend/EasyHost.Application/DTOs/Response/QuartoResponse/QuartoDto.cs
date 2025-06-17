
namespace EasyHost.Application.DTOs.Response.QuartoResponse
{
    public class QuartoDto
    {
        public Guid id { get; set; }
        public int numQuarto { get; set; }
        public int numCamasSolteiro { get; set; }
        public int numCamasCasal { get; set; }
        public int maxPessoas { get; set; }
        public Guid hotelId { get; set; }
        public decimal precoDiaria { get; set; }
    }
}
