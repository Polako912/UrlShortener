using LiteDB.Async;

namespace UrlShortener.Infrastructure.Interfaces
{
    public interface IDbConnectionProvider
    {
        LiteDatabaseAsync GetLiteDatabaseAsync();
    }
}