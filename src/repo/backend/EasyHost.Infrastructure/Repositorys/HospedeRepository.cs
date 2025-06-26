using Dapper;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Infrastructure.Data;
using EasyHost.Infrastructure.Repositorys;

namespace EasyHost.Infrastructure.Repositories
{
    public class HospedeRepository : BaseRepository, IHospedeRepository
    {
        public HospedeRepository(IDataConnection context)
                                : base(context)
        {
        }


        public Hospede GetHospedeById(Guid id)
        {
            const string sql = @"SELECT
                id            AS id,
                nome          AS nome,
                cpf           AS cpf,
                hotelIdFk     AS hotelId
            FROM Hospede
            WHERE id = @Id;";
            return connection.QueryFirstOrDefault<Hospede>(sql, new { Id = id });
        }

        public Hospede GetHospedeByCpf(string cpf)
        {
            const string sql = @"SELECT
                id            AS id,
                nome          AS nome,
                cpf           AS cpf,
                hotelIdFk     AS hotelId
            FROM Hospede
            WHERE cpf = @Cpf;";
            return connection.QueryFirstOrDefault<Hospede>(sql, new { Cpf = cpf });
        }

        public void CreateHospede(Hospede hospede)
        {
            const string sql = @"INSERT INTO Hospede
                (id, nome, cpf, hotelIdFk)
            VALUES
                (@Id, @Nome, @Cpf, @HotelId);";
            connection.Execute(sql, new
            {
                Id = hospede.id,
                Nome = hospede.nome,
                Cpf = hospede.cpf,
                HotelId = hospede.hotelId
            });
        }

        public IEnumerable<Hospede> GetAllHospede(Guid hotelId)
        {
            const string sql = @"
            SELECT
            id            AS id,
            nome          AS nome,
            cpf           AS cpf,
            hotelIdFk     AS hotelId
            FROM Hospede
            WHERE hotelIdFk = @hotelId;";

            return connection.Query<Hospede>(sql, new { hotelId });
        }


        public void DeletarHospede(Guid id)
        {
            const string sql = "DELETE FROM Hospede WHERE id = @Id;";
            connection.Execute(sql, new { Id = id });
        }
    }
}