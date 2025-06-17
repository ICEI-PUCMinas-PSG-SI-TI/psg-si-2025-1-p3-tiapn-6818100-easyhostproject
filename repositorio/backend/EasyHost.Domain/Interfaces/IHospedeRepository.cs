using EasyHost.Domain.Entities;

namespace EasyHost.Domain.Interfaces
{
    public interface IHospedeRepository
    {
        Hospede GetHospedeById(Guid id);
        Hospede GetHospedeByCpf(string cpf);
        void CreateHospede(Hospede hospede);
        IEnumerable<Hospede> GetAllHospede(Guid hotelId);
        void DeletarHospede(Guid id);
    }
}
