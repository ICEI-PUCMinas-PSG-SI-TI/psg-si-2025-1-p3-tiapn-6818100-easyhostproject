using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace EasyHost.Infrastructure.Data
{
    public sealed class DataConnection : IDataConnection
    {
        private readonly string _connectionString;
        public DataConnection(IConfiguration cfg) => _connectionString = cfg.GetConnectionString("Default")
                                                                      ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        public SqlConnection CreateConnection() => new(_connectionString);
    }
}
