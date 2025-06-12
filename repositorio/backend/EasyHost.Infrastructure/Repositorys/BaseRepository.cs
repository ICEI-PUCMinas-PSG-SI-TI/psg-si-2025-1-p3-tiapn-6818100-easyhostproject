using EasyHost.Infrastructure.Data;
using System.Data;


namespace EasyHost.Infrastructure.Repositorys
{
    public abstract class BaseRepository
    {
        private readonly IDataConnection _context;
        protected IDbConnection connection => _context.CreateConnection();

        protected BaseRepository(IDataConnection context)
        {
            _context = context;
        }
    }
}
