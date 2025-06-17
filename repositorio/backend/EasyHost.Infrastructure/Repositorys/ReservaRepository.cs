using Dapper;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Infrastructure.Data;
using EasyHost.Infrastructure.Repositorys;

namespace EasyHost.Infrastructure.Repositories
{
    public class ReservaRepository : BaseRepository, IReservaRepository
    {
        public ReservaRepository(IDataConnection context)
            : base(context)
        {
        }

        public void CreateReserva(Reserva reserva)
        {
            const string sql = @"INSERT INTO Reserva
                (id, hospedeIdFk, quartoIdFk, dataEntrada, dataSaida, statusReservaIdFk, hotelIdFk)
            VALUES
                (@Id, @HospedeId, @QuartoId, @DataEntrada, @DataSaida, @StatusReserva, @HotelId);";

            connection.Execute(sql, new
            {
                Id = reserva._id,
                HospedeId = reserva._hospedeId,
                QuartoId = reserva._quartoId,
                DataEntrada = reserva._dataEntrada,
                DataSaida = reserva._dataSaida,
                HotelId = reserva._hotelId,
                StatusReserva = (int)reserva._statusReserva
            });
        }

        public Reserva GetReservaById(Guid id)
        {
            const string sql = @"SELECT
                id            AS _id,
                hospedeIdFk     AS _hospedeId,
                quartoIdFk      AS _quartoId,
                dataEntrada   AS _dataEntrada,
                dataSaida     AS _dataSaida,
                statusReservaIdFk AS _statusReserva
            FROM Reserva
            WHERE id = @Id;";

            return connection.QueryFirstOrDefault<Reserva>(sql, new { Id = id });
        }

        public IEnumerable<Reserva> GetAllReservas(Guid hotelId)
        {
            const string sql = @"SELECT
                id            AS _id,
                hospedeIdFk     AS _hospedeId,
                quartoIdFk      AS _quartoId,
                dataEntrada   AS _dataEntrada,
                dataSaida     AS _dataSaida,
                statusReservaIdFk AS _statusReserva
                FROM Reserva
                WHERE hotelIdFk = @hotelId;";

            return connection.Query<Reserva>(sql, new { hotelId });
        }

        public void UpdateReserva(Reserva reserva)
        {
            const string sql = @"UPDATE Reserva SET
                hospedeIdFk     = @HospedeId,
                quartoIdFk      = @QuartoId,
                dataEntrada   = @DataEntrada,
                dataSaida     = @DataSaida,
                statusReservaIdFk = @StatusReserva
            WHERE id = @Id;";

            connection.Execute(sql, new
            {
                Id = reserva._id,
                HospedeId = reserva._hospedeId,
                QuartoId = reserva._quartoId,
                DataEntrada = reserva._dataEntrada,
                DataSaida = reserva._dataSaida,
                StatusReserva = (int)reserva._statusReserva
            });
        }

        public void DeleteReserva(Guid id)
        {
            const string sql = "DELETE FROM Reserva WHERE id = @Id;";
            connection.Execute(sql, new { Id = id });
        }
    }
}
