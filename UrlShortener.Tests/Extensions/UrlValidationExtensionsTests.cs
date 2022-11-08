using NUnit.Framework;
using UrlShortener.Domain.Extensions;

namespace UrlShortener.Tests.Extensions
{
    [TestFixture]
    public class UrlValidationExtensionsTests
    {
        [TestCase("https://www.google.com", ExpectedResult = true)]
        [TestCase("https://www.google.com/fsagfsa", ExpectedResult = true)]
        [TestCase("https://www.google.com/fsagfsa?sfsa", ExpectedResult = true)]
        [TestCase("https://www.google.com/fsagfsa/sadfsd", ExpectedResult = true)]
        [TestCase("https://google.com", ExpectedResult = true)]
        [TestCase("http://www.google.com", ExpectedResult = true)]
        [TestCase("http://google.com", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("  ", ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        [TestCase("swagger/swagger", ExpectedResult = false)]
        [TestCase("test", ExpectedResult = false)]
        [TestCase("swagger/index.html", ExpectedResult = false)]
        public bool UrlValidationExtensionsTest(string input)
            => UrlValidationExtensions.IsUrlValid(input);
    }
}