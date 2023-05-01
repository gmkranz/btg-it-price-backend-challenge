using Application.Services.Impl;
using AutoFixture;
using NUnit.Framework;
using System;

namespace UnitTests.Core.Application
{
    [TestFixture]
    [TestOf(typeof(GithubReposServiceTests))]
    public class GithubReposServiceTests
    {
        //TODO: finish unit tests
        IFixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        [TestCase("JavaScript,", "language:JavaScript")]
        [TestCase("Python,Java", "language:Python+OR+language:Java")]
        [TestCase("Go,Ruby,C++", "language:Go+OR+language:Ruby+OR+language:C++")]
        public void Should_StandardLanguageRequest_WithValidLanguages_ReturnsExpectedResult(string languages, string expected)
        {
            var result = GithubReposService.StandardLanguageRequest(languages);
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Should_IsMaxLanguagesRequest_WithTooManyLanguages_ThrowsArgumentException()
        {
            var languagesArray = new string[] { "C#", "JavaScript", "Python", "Java", "Go", "Ruby", "C++" };
            var expectedMessage = "O número máximo de linguagens permitido é 5.";

            var ex = Assert.Throws<ArgumentException>(() => GithubReposService.IsMaxLanguagesRequest(languagesArray));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase("C#,Java,Python,Ruby,Go")]
        [TestCase("C#,Java,Python,Ruby")]
        [TestCase("C#,Java,Python")]
        [TestCase("C#,Java")]
        [TestCase("C#")]
        public void Should_ValidateLanguagesRequest_WithValidLanguages_DoNotThrowException(string languages)
        {
            Assert.DoesNotThrow(() => GithubReposService.ValidateLanguagesRequest(languages));
        }

        [TestCase("C#,Java,Python,Ruby,Go,JavaScript")]
        [TestCase("C#,Java,Python,Ruby,Go,JavaScript,C++")]
        public void Should_ValidateLanguagesRequest_WithMoreThanFiveLanguages_ThrowsArgumentException(string languages)
        {
            Assert.Throws<ArgumentException>(() => GithubReposService.ValidateLanguagesRequest(languages));
        }
    }
}
