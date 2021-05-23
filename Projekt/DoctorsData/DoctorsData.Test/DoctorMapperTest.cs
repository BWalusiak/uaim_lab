namespace DoctorsData.Test
{
    using System;
    using System.Collections.Generic;
    using Application.Dtos;
    using Application.Mapper;
    using Domain.Models;
    using FluentAssertions;
    using Xunit;

    public class DoctorMapperTest
    {
        [Fact]
        public void ShouldUnmap()
        {
            // Arrange
            var date = new DateTime();
            var dto = new DoctorDto
            {
                Id = 12,
                Name = "Stefan",
                Sex = "Male",
                Pesel = "12345678901",
                Specializations = new[]
                {
                    new SpecializationDto { Type = 1, CertificationDate = date },
                    new SpecializationDto { Type = 2, CertificationDate = date.AddDays(8) }
                }
            };

            // Act
            var obj = dto.UnMap();

            // Assert
            obj.Id.Should().Be(12);
            obj.Name.Should().Be("Stefan");
            obj.Pesel.Should().Be("12345678901");
            obj.Sex.Should().Be(Sex.Male);
            obj.Specializations.Should().ContainInOrder(
                new Specialization { Type = 1, CertificationDate = date },
                new Specialization { Type = 2, CertificationDate = date.AddDays(8) });
        }

        [Fact]
        public void ShouldMap()
        {
            // Arrange
            var date = new DateTime();
            var obj = new Doctor
            {
                Id = 12,
                Name = "Stefan",
                Pesel = "12345678901",
                Sex = Sex.Male,
                Specializations = new List<Specialization>(new[]
                {
                    new Specialization { Type = 1, CertificationDate = date },
                    new Specialization { Type = 2, CertificationDate = date.AddDays(8) }
                })
            };

            // Act
            var dto = obj.Map();

            // Assert
            dto.Id.Should().Be(12);
            dto.Name.Should().Be("Stefan");
            dto.Sex.Should().Be("Male");
            dto.Specializations.Should().ContainInOrder(
                new SpecializationDto { Type = 1, CertificationDate = date },
                new SpecializationDto { Type = 2, CertificationDate = date.AddDays(8) });
        }
    }
}
