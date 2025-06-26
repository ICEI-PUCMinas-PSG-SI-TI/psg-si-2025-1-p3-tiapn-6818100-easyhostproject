
namespace EasyHost.Application.DTOs.Request.QuartoRequest
{
    public class UpdateQuartoDto
    {
        public Guid id { get; set; }
        public int numCamasSolteiro { get; set; }
        public int numCamasCasal { get; set; }
        public int maxPessoas { get; set; }
        public decimal precoDiaria { get; set; }

    }
}
