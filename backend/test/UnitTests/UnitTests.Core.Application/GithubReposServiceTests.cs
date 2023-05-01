using Application.Services.Impl;
using AutoFixture;
using NUnit.Framework;

namespace UnitTests.Core.Application
{
    [TestFixture]
    [TestOf(typeof(GithubReposServiceTests))]
    public class GithubReposServiceTests
    {

        IFixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        [TestCase("C#", "C#")]
        [TestCase("JavaScript,", "JavaScript")]
        [TestCase("Python&Java", "Python,Java")]
        [TestCase("Go&Ruby&C++", "Go,Ruby,C++")]
        public void StandardLanguageRequest_WithValidLanguages_ReturnsExpectedResult(string languages, string expected)
        {
            // Arrange
            var service = _fixture.Create<GithubReposService>();

            var result = GithubReposService.StandardLanguageRequest(languages);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
