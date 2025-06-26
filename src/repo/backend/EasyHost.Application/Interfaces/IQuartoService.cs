using EasyHost.Application.DTOs.Request.QuartoRequest;
using EasyHost.Application.DTOs.Response.QuartoResponse;

namespace EasyHost.Application.Interfaces
{
    public interface IQuartoService
    {
        QuartoDto CadastrarQuartoAsync(CreateQuartoDto dto);
        IEnumerable<QuartoDto> GetAllQuartos(Guid hotelId);
        QuartoDto GetQuartoPorId(Guid id);
        void AlterarQuartoAsync(UpdateQuartoDto dto);
        void RemoverQuartoAsync(Guid id);
        IEnumerable<QuartoDto> ObterQuartosDisponiveis(DateOnly dataInicial, Guid hotelId);
    }
}
