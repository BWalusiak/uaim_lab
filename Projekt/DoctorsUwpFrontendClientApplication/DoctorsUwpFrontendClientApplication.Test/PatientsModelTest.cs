namespace DoctorsUwpFrontendClientApplication.Test
{
    using FluentAssertions;
    using Models;
    using Xunit;

    public class PatientModelTest
    {
        [Fact]
        public void ShouldHaveAnEmptyDefaultConstructor()
        {
            // Arrange & Act
            var patient = new PatientDto();
            
            // Assert
            patient.Id.Should().Be(0);
            patient.Name.Should().BeEmpty();
            patient.Sex.Should().BeEmpty();
            patient.Conditions.Should().BeEmpty();
        }
    }
}