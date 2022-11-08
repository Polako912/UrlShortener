using LiteDB.Async;
using Microsoft.Extensions.Configuration;
using UrlShortener.Infrastructure.Interfaces;

namespace UrlShortener.Infrastructure
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public DbConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LiteDatabaseAsync GetLiteDatabaseAsync()
            => new LiteDatabaseAsync(_configuration.GetConnectionString("LiteDb"));
    }
}