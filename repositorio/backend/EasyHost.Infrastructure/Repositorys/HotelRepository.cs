using EasyHost.Domain.Entities;
using EasyHost.Infrastructure.Data;
using Dapper;
using EasyHost.Domain.Interfaces;

namespace EasyHost.Infrastructure.Repositorys
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(IDataConnection context)
            : base(context)
        {
        }

        public IEnumerable<Hotel> GetAll()
        {
            var sql = "SELECT * FROM Hotel"; // query q sera executada no banco
            return connection.Query<Hotel>(sql);  // executa a querry e mapeia cada linha retornada do banco para o objeto Hotel
        }

        public Hotel? GetHotelById(Guid id)
        {
            const string sql = @"
            SELECT
            id        AS Id,
            nomeHotel AS NomeHotel
            FROM Hotel
            WHERE id = @Id;";

            return connection.QueryFirstOrDefault<Hotel>(sql, new { Id = id });
        }

    }
}
