namespace SGP.Tests.UnitTests.Shared.Extensions
{
    using Ardalis.GuardClauses;
    using Constants;
    using FluentAssertions;
    using Microsoft.Extensions.Options;
    using SGP.Shared.AppSettings;
    using SGP.Shared.Extensions;
    using System;
    using Xunit;
    using Xunit.Categories;

    [UnitTest(TestCategories.Shared)]
    public class GuardExtensionsTests
    {
        [Fact]
        public void Should_NotThrowsArgumentNullException_WhenInputIsNotNull()
        {
            // Arrange
            var options = Options.Create(AuthConfig.Create(3, 1000));

            // Act
            Action act = () => Guard.Against.NullOptions(options, nameof(options));

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Should_ThrowsArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            IOptions<AuthConfig> options = null;
            var expectedMessage = $"A seção '{nameof(AuthConfig)}' não está configurada no appsettings.json";

            // Act
            Action act = () => Guard.Against.NullOptions(options, nameof(options));

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().WithMessage($"*{expectedMessage}*");
        }

        [Fact]
        public void Should_ThrowsArgumentNullException_WhenInputValueIsNull()
        {
            // Arrange
            var options = Options.Create<AuthConfig>(null);
            var expectedMessage = $"A seção '{nameof(AuthConfig)}' não está configurada no appsettings.json";

            // Act
            Action act = () => Guard.Against.NullOptions(options, nameof(options));

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().WithMessage($"*{expectedMessage}*");
        }
    }
}