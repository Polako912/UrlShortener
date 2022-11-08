using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces.Services
{
    public interface IUrlShortenerService
    {
        Task<string> CreateShortUrl(string sourceUrl);

        Task<IEnumerable<ShortenedUrlDto>> GetAllShortenedUrls();

        Task<string?> GetUrlByCode(string code);
    }
}