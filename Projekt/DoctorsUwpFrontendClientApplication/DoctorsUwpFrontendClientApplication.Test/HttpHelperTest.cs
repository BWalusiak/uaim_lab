namespace DoctorsUwpFrontendClientApplication.Test
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Controller.Rest;
    using FluentAssertions;
    using Microsoft.VisualBasic;
    using Xunit;

    public class HttpHelperTest
    {
        [Fact]
        public void ShouldCreateBaseClient()
        {
            // Arrange
            var httpHelper = new HttpHelper("http://this-is-url:123");
            
            // Act
            var client = httpHelper.BaseClient();
            
            // Assert
            client.BaseAddress.Should().Be("http://this-is-url:123");
        }

        [Fact]
        public void ShouldThrowHttpRequestExceptionOnInvalidUrl()
        {
            // Arrange
            var httpHelper = new HttpHelper("http://this-is-url:123");
            
            // Act
            Func<Task> act = async () => await httpHelper.GetAsync<int>("/");
            
            // Assert
            act.Should().ThrowExactly<HttpRequestException>().WithMessage("Name or service not known*");
        }
    }
}