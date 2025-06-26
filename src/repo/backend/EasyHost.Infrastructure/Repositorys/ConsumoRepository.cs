using Dapper;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Infrastructure.Data;

namespace EasyHost.Infrastructure.Repositorys
{
    public class ConsumoRepository : BaseRepository, IConsumoRepository
    {
        public ConsumoRepository(IDataConnection context)
            : base(context)
        {
        }

        public void CreateConsumo(Consumo consumo)
        {
            const string sql = @"INSERT INTO Consumo
                (id, hospedeIdFk, nome, preco, hotelIdFk)
            VALUES
                (@Id, @HospedeId, @Nome, @Preco, @HotelId);";
            connection.Execute(sql, new
            {
                Id = consumo.id,
                HospedeId = consumo.hospedeId,
                Nome = consumo.nome,
                Preco = consumo.preco,
                HotelId = consumo.hotelId
            });
        }

        public IEnumerable<Consumo> GetConsumosByHospedeId(Guid hospedid)
        {
            const string sql = @"SELECT
             id             AS Id,
             hospedeIdFk    AS HospedeId,
             nome      AS  Nome,
            preco          AS Preco
            FROM Consumo
            WHERE hospedeIdFk = @HospedeId;
            ";

            return connection.Query<Consumo>(sql, new { HospedeId = hospedid }).ToList();
        }

        public IEnumerable<Consumo> GetAllConsumos(Guid hotelId)
        {
            const string sql = @"SELECT
             id             AS Id,
             hospedeIdFk    AS HospedeId,
             nome      AS  Nome,
             preco          AS Preco
             FROM Consumo
             WHERE hotelIdFk = @HotelId;
            ";

            return connection.Query<Consumo>(sql, new { HotelId = hotelId }).ToList();
        }

        public void DeletarConsumo(Guid id)
        {
            const string sql = "DELETE FROM Consumo WHERE id = @Id;";
            connection.Execute(sql, new { Id = id });
        }
    }
}
