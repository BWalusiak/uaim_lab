using System;
using Xunit;

namespace Test
{
    using FluentAssertions;
    using Model.Configuration;

    public class ServiceConfigurationTest
    {
        [Fact]
        public void ShouldThrowNullArgumentExceptionOnNullBackendUrl()
        {
            // Arrange & Act
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new ServiceConfiguration(null);

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*backendUrl*");
        }

        [Fact]
        public void ShouldCreateAnInstanceOfAnObject()
        {
            // Arrange & act
            var config = new ServiceConfiguration("http://localhost");

            // Assert
            config.BackendUrl.Should().Be("http://localhost");
        }
    }
}