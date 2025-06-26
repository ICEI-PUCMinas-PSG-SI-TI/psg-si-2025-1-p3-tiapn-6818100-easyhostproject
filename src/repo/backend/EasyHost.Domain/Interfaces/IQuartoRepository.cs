using EasyHost.Domain.Entities;

namespace EasyHost.Domain.Interfaces
{
    public interface IQuartoRepository
    {
        void CreateQuarto(Quarto quarto);
        Quarto? GetQuartoById(Guid id);
        IEnumerable<Quarto> GetAllQuartos(Guid hotelId);
        void AtualizarQuarto(Quarto quarto);
        void DeletarQuarto(Guid id);
    }
}
