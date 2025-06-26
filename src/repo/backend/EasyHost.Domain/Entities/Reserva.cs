using EasyHost.Domain.Enums;

namespace EasyHost.Domain.Entities
{
    public class Reserva
    {
        public Guid _id { get; private set; }
        public Guid _hospedeId { get; private set; }
        public Guid _quartoId { get; private set; }
        public Guid _hotelId { get; private set; }
        public DateTime _dataEntrada { get; private set; }
        public DateTime _dataSaida { get; private set; }
        public StatusReserva _statusReserva { get; private set; }

        protected Reserva() { }

        public Reserva(Guid hospedeId, Guid quartoId, Guid hotelIdFk, DateTime dataEntrada, DateTime dataSaida)
        {
            if (dataEntrada >= dataSaida)
                throw new ArgumentException("Data de entrada deve ser anterior à data de saída");

            _id = Guid.NewGuid();
            _hospedeId = hospedeId;
            _quartoId = quartoId;
            _hotelId = hotelIdFk;
            _dataEntrada = dataEntrada;
            _dataSaida = dataSaida;
            _statusReserva = StatusReserva.Reservada;
        }

        public void AlterarReserva(StatusReserva novoStatus)
        {
            _statusReserva = novoStatus;
        }
    }

}
