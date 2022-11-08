using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.Extensions;
using UrlShortener.Domain.Interfaces.Services;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    public class UrlShotenerController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortenerService;
        private readonly ILogger<UrlShotenerController> _logger;

        public UrlShotenerController(IUrlShortenerService urlShortenerService,
            ILogger<UrlShotenerController> logger)
        {
            _urlShortenerService = urlShortenerService;
            _logger = logger;
        }

        [HttpPost("short-url")]
        public async Task<IActionResult> CreateShortenedUrl([FromQuery] string sourceUrl)
        {
            _logger.LogInformation($"Requested {sourceUrl} to be shortened");

            if (!UrlValidationExtensions.IsUrlValid(sourceUrl))
                return BadRequest("Url is not in correct format");

            var result = await _urlShortenerService.CreateShortUrl(sourceUrl);

            _logger.LogInformation($"Shortened url: {result}");

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"Retrieving all shortened urls");

            var result = await _urlShortenerService.GetAllShortenedUrls();

            return Ok(result);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GoToDestination(string code)
        {
            var result = await _urlShortenerService.GetUrlByCode(code);

            _logger.LogInformation($"Redirecting to desitnation site: {result}");

            return new RedirectResult(result, true);
        }
    }
}