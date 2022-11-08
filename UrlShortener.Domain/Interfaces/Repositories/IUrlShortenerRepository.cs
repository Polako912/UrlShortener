using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces.Repositories
{
    public interface IUrlShortenerRepository
    {
        Task<string> CreateShortUrl(string sourceUrl);

        Task<IEnumerable<ShortenedUrl>> GetAllShortenedUrls();

        Task<string?> GetUrlByCode(string code);
    }
}