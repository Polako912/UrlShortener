using Microsoft.Extensions.Configuration;
using UrlShortener.Domain.Extensions;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Interfaces;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UrlShortenerRepository : IUrlShortenerRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;
        private readonly IConfiguration _configuration;

        public UrlShortenerRepository(IDbConnectionProvider dbConnectionProvider,
            IConfiguration configuration)
        {
            _dbConnectionProvider = dbConnectionProvider;
            _configuration = configuration;
        }

        public async Task<string> CreateShortUrl(string sourceUrl)
        {
            var appUrl = _configuration.GetSection("Urls").Value;

            var shortUrl = UrlShortenerExtensions.CreateShortenedUrl(sourceUrl, appUrl);

            using (var connection = _dbConnectionProvider.GetLiteDatabaseAsync())
            {
                var collection = connection.GetCollection<ShortenedUrl>();

                await collection.UpsertAsync(shortUrl);
            }

            return shortUrl?.ShortUrl;
        }

        public async Task<IEnumerable<ShortenedUrl>> GetAllShortenedUrls()
        {
            var shortenedUrls = new List<ShortenedUrl>();

            using (var connection = _dbConnectionProvider.GetLiteDatabaseAsync())
            {
                var collection = connection.GetCollection<ShortenedUrl>(nameof(ShortenedUrl));

                var results = await collection.Query().OrderBy(x => x.Id).ToArrayAsync();

                shortenedUrls.AddRange(results);
            }

            return shortenedUrls;
        }

        public async Task<string?> GetUrlByCode(string code)
        {
            string? result = string.Empty;

            using (var connection = _dbConnectionProvider.GetLiteDatabaseAsync())
            {
                var collection = connection.GetCollection<ShortenedUrl>(nameof(ShortenedUrl));

                var shortenedUrl = await collection.Query().Where(x => x.Code == code).FirstOrDefaultAsync();

                result = shortenedUrl?.SourceUrl;
            }

            return result;
        }
    }
}