using Xunit;

namespace DoctorsUwpFrontendClientApplication.Test
{
    using FluentAssertions;
    using Models;

    public class DoctorModelTest
    {
        [Fact]
        public void ShouldHaveAnEmptyDefaultConstructor()
        {
            // Arrange & Act
            var doctor = new DoctorDto();
            
            // Assert
            doctor.Id.Should().Be(0);
            doctor.Name.Should().BeEmpty();
            doctor.Sex.Should().BeEmpty();
            doctor.Specializations.Should().BeEmpty();
        }
    }
}