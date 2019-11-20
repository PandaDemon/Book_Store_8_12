using Microsoft.Extensions.Configuration;

namespace PrintStore.DataAccess.Repositories.ConnectionStringProvider
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _config;

        public ConnectionStringProvider(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
    }
}
