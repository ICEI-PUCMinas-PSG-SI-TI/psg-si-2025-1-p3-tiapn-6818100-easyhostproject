using Microsoft.Data.SqlClient;

namespace EasyHost.Infrastructure.Data
{
    public interface IDataConnection
    {
        SqlConnection CreateConnection();
    }
}
