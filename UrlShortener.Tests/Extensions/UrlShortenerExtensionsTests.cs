using FluentAssertions;
using NUnit.Framework;
using UrlShortener.Domain.Extensions;

namespace UrlShortener.Tests.Extensions
{
    [TestFixture]
    public class UrlShortenerExtensionsTests
    {
        [Test]
        public void UrlShortenerExtensions_ValidUrl_ReturnsValidObject()
        {
            //Arrage
            var sourceUrl = "https://www.google.com";
            var appUrl = "https://localhost";

            //Act
            var result = UrlShortenerExtensions.CreateShortenedUrl(sourceUrl, appUrl);

            //Asert
            result.Should().NotBeNull();
            result.Should().NotBe(string.Empty);
            result.ShortUrl.Should().Contain("localhost");
            result.ShortUrl.Should().NotContain("google");
            result.SourceUrl.Should().Be(sourceUrl);
        }
    }
}