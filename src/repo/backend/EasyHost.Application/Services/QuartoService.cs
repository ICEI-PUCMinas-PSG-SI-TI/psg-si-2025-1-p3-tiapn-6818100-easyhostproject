using EasyHost.Application.DTOs.Request.QuartoRequest;
using EasyHost.Application.DTOs.Response.QuartoResponse;
using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Enums;
using EasyHost.Domain.Interfaces;
using Mapster;

namespace EasyHost.Application.Services
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _quartoRepository;
        private readonly IReservaRepository _reservaRepository;

        public QuartoService(
            IQuartoRepository quartoRepository,
            IReservaRepository reservaRepository)
        {
            _quartoRepository = quartoRepository;
            _reservaRepository = reservaRepository;
        }

        public QuartoDto CadastrarQuartoAsync(CreateQuartoDto dto)
        {
            var quarto = new Quarto(
                dto.numQuarto,
                dto.numCamasSolteiro,
                dto.numCamasCasal,
                dto.maxPessoas,
                dto.hotelId,
                dto.precoDiaria
            );

            _quartoRepository.CreateQuarto(quarto);

            QuartoDto quartoDto = quarto.Adapt<QuartoDto>(); 
            return quartoDto;
        }

        public IEnumerable<QuartoDto> GetAllQuartos(Guid hotelId)
        {
            var quartos = _quartoRepository.GetAllQuartos(hotelId).OrderBy(q => q.numQuarto);

            return quartos.Adapt<IEnumerable<QuartoDto>>();
        }

        public QuartoDto GetQuartoPorId(Guid id)
        {
            var quarto = _quartoRepository.GetQuartoById(id)
                ?? throw new KeyNotFoundException("Quarto não encontrado.");

            return quarto.Adapt<QuartoDto>();
        }

        public void AlterarQuartoAsync(UpdateQuartoDto dto)
        {
            var quarto = _quartoRepository.GetQuartoById(dto.id)
                ?? throw new KeyNotFoundException("Quarto não encontrado.");

            quarto.AlterarQuarto(dto.numCamasSolteiro, dto.numCamasCasal, dto.maxPessoas, dto.precoDiaria);

             _quartoRepository.AtualizarQuarto(quarto);
        }

        public void RemoverQuartoAsync(Guid id)
        {
            var quarto = _quartoRepository.GetQuartoById(id)
                ?? throw new KeyNotFoundException("Quarto não encontrado.");

            _quartoRepository.DeletarQuarto(id);
        }

        public IEnumerable<QuartoDto> ObterQuartosDisponiveis(DateOnly dataInicial, Guid hotelId)
        {
            var reservas = _reservaRepository.GetAllReservas(hotelId);
            var quartosOcupados = reservas.Where(r => r._statusReserva != StatusReserva.Concluida && r._statusReserva != StatusReserva.Cancelada 
                                                 &&  r._dataEntrada >= dataInicial.ToDateTime(TimeOnly.MinValue)).Select(r => r._quartoId).Distinct();

            var allQuartos = _quartoRepository.GetAllQuartos(hotelId);
            var quartosLivres = allQuartos.Where(q => !quartosOcupados.Contains(q.id));

            return quartosLivres.Adapt<IEnumerable<QuartoDto>>();
        }
    }
}
