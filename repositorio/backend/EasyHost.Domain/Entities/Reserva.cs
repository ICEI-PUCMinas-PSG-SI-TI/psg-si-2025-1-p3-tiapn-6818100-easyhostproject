using EasyHost.Domain.Enums;

namespace EasyHost.Domain.Entities
{
    public class Reserva
    {
        private Guid _id;
        private int _hospedeId;
        private int _quartoId;
        private DateOnly _dataEntrada;
        private DateOnly _dataSaida;
        private StatusReserva _statusReserva;
        private List<Servico> _servicos = new();

        public Reserva(int hospedeId, int quartoId, DateOnly dataEntrada, DateOnly dataSaida)
        {
            if (dataEntrada >= dataSaida)
                throw new ArgumentException("Data de entrada deve ser anterior à data de saída");

            _id = Guid.NewGuid();
            _hospedeId = hospedeId;
            _quartoId = quartoId;
            _dataEntrada = dataEntrada;
            _dataSaida = dataSaida;
            _statusReserva = StatusReserva.Reservada;
        }

        public void ChangeStatusReserva(StatusReserva novoStatus)
        {
            _statusReserva = novoStatus;
        }

        public void AdicionarServico(Servico servico)
        {
            _servicos.Add(servico);
        }

    }

}
