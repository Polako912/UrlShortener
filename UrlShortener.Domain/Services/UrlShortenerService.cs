using AutoMapper;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Interfaces.Services;

namespace UrlShortener.Domain.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly IUrlShortenerRepository _urlShortenerRepository;
        private readonly IMapper _mapper;

        public UrlShortenerService(IUrlShortenerRepository urlShortenerRepository,
            IMapper mapper)
        {
            _urlShortenerRepository = urlShortenerRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateShortUrl(string sourceUrl)
        {
            var result = await _urlShortenerRepository.CreateShortUrl(sourceUrl);

            return result;
        }

        public async Task<IEnumerable<ShortenedUrlDto>> GetAllShortenedUrls()
        {
            var result = await _urlShortenerRepository.GetAllShortenedUrls();

            return _mapper.Map<IEnumerable<ShortenedUrlDto>>(result);
        }

        public async Task<string?> GetUrlByCode(string code)
        {
            var result = await _urlShortenerRepository.GetUrlByCode(code);

            return result;
        }
    }
}