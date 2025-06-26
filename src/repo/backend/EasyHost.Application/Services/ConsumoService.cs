using EasyHost.Application.DTOs.Request.ConsumoRequest;
using EasyHost.Application.DTOs.Response.ConsumoResponse;
using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using Mapster;

namespace EasyHost.Application.Services
{
    public class ConsumoService : IConsumoService
    {
        private readonly IConsumoRepository _consumoRepository;

        public ConsumoService(IConsumoRepository consumoRepository)
        {
            _consumoRepository = consumoRepository;
        }

        public ConsumoDto CreateConsumo(CreateConsumoDto dto)
        {
            var consumo = new Consumo(
                dto.nome,
                dto.preco,
                dto.hospedeId,
                dto.hotelId
            );

            _consumoRepository.CreateConsumo(consumo);
            return consumo.Adapt<ConsumoDto>();
        }

        public IEnumerable<ConsumoDto> GetConsumosByHospedeId(Guid hospedeId)
        {
            var consumos = _consumoRepository.GetConsumosByHospedeId(hospedeId);
            return consumos.Adapt<IEnumerable<ConsumoDto>>();
        }

        public IEnumerable<Object> GetConsumosFrequencia(Guid hotelId)
        {
            var consumosFrequencia = _consumoRepository.GetAllConsumos(hotelId).GroupBy(c => c.nome.ToLower()).Select(g => new
            {
                nome = g.Key,
                Quantidade = g.Count()
            })
            .ToList();

            return consumosFrequencia;
        }

        public void DeleteConsumo(Guid id)
        {
            _consumoRepository.DeletarConsumo(id);
        }
    }
}
