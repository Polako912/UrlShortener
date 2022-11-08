using shortid;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Extensions
{
    public static class UrlShortenerExtensions
    {
        public static ShortenedUrl CreateShortenedUrl(string sourceUrl, string appUrl)
        {
            var urlCode = ShortId.Generate();

            var shortUrl = new ShortenedUrl
            {
                SourceUrl = sourceUrl,
                Code = urlCode,
                ShortUrl = $"{appUrl}/{urlCode}"
            };

            return shortUrl;
        }
    }
}