namespace UrlShortener.Domain.Dtos
{
    public class ShortenedUrlDto
    {
        public string? SourceUrl { get; set; }

        public string? ShortUrl { get; set; }
    }
}