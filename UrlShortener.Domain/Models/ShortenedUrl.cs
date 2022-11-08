using LiteDB;

namespace UrlShortener.Domain.Models
{
    public class ShortenedUrl
    {
        [BsonId]
        public int Id { get; set; }

        public string? SourceUrl { get; set; }

        public string? ShortUrl { get; set; }

        public string? Code { get; set; }
    }
}