using EasyHost.Domain.Entities;
using EasyHost.Infrastructure.Data;
using Dapper;
using EasyHost.Domain.Interfaces;

namespace EasyHost.Infrastructure.Repositorys
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IDataConnection _context;

        public HotelRepository(IDataConnection dataConnection)
        {
            _context = dataConnection;
        }

        public IEnumerable<Hotel> GetAll()
        {
            using var connection = _context.CreateConnection(); //isso faz a conexão com o banco usando o IDataConnection
            var sql = "SELECT * FROM Hotel"; // query q sera executada no banco
            return connection.Query<Hotel>(sql);  // executa a querry e mapeia cada linha retornada do banco para o objeto Hotel
        }

    }
}
