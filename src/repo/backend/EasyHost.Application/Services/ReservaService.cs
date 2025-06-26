using EasyHost.Application.DTOs.Request.ReservaRequest;
using EasyHost.Application.DTOs.Response.ReservaResponse;
using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using Mapster;

namespace EasyHost.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IQuartoRepository _quartoRepository;
        private readonly IHospedeRepository _hospedeRepository;
        private readonly IHospedeService _hospedeService;


        public ReservaService(IReservaRepository reservaRepository, IQuartoRepository quartoRepository,
                                IHospedeRepository hospedeRepository, IHospedeService hospedeService)
        {
            _reservaRepository = reservaRepository;
            _quartoRepository = quartoRepository;
            _hospedeRepository = hospedeRepository;
            _hospedeService = hospedeService;

        }

        public ReservaDto CadastrarReserva(CreateReservaDto dto)
        {
            var reserva = new Reserva(
                dto._hospedeId,
                dto._quartoId,
                dto._hotelId,
                dto._dataEntrada,
                dto._dataSaida
            );
            _reservaRepository.CreateReserva(reserva);
            return reserva.Adapt<ReservaDto>();
        }

        public IEnumerable<ReservaDto> GetAllReservas(Guid hotelId)
        {
            var reservas = _reservaRepository.GetAllReservas(hotelId);
            return reservas.Adapt<IEnumerable<ReservaDto>>();
        }

        public ReservaDto GetReservaPorId(Guid id)
        {
            var reserva = _reservaRepository.GetReservaById(id)
                ?? throw new KeyNotFoundException("Reserva não encontrada");

            return reserva.Adapt<ReservaDto>();
        }

        public void AlterarReserva(UpdateReservaDto dto)
        {
            var reserva = _reservaRepository.GetReservaById(dto._id)
                ?? throw new KeyNotFoundException("Reserva não encontrada");

            reserva.AlterarReserva(dto._statusReserva);
            _reservaRepository.UpdateReserva(reserva);
        }

        public void CancelarReserva(Guid id)
        {
            _reservaRepository.DeleteReserva(id);
        }

        public decimal CalcularPrecoReserva(Guid id)
        {
            var reserva = _reservaRepository.GetReservaById(id)
                ?? throw new KeyNotFoundException("Reserva não encontrada");

            var quarto = _quartoRepository.GetQuartoById(reserva._quartoId)
                ?? throw new KeyNotFoundException("Quarto não encontrado");

            var hospede = _hospedeRepository.GetHospedeById(reserva._hospedeId)
                ?? throw new KeyNotFoundException("Hospede não encontrado");

            int diasReservados = (reserva._dataSaida - reserva._dataEntrada).Days;

            var precoReservas = diasReservados * quarto.precoDiaria;

            decimal precoConsumo = _hospedeService.GetValorTotalConsumo(hospede.id);

            return precoConsumo + precoReservas;
        }

        public double GetTempoMediaReserva(Guid hotelId)
        {
            IEnumerable<Reserva> listaReservas = _reservaRepository.GetAllReservas(hotelId);
            if (listaReservas == null || !listaReservas.Any())
            {
                return 0;
            }

            double tempoMediaReserva = listaReservas.Select(r => (r._dataSaida - r._dataEntrada).TotalDays).Average();

            return tempoMediaReserva;
        }
    }
}
