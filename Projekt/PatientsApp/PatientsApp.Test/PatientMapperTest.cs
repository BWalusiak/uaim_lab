using System;
using Xunit;

namespace PatientsApp.Test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Infrastrucutre.Models;
    using PatientsData.Infrastructure.Models;
    using Web.Application.Dtos;
    using Web.Mapper;

    public class PatientMapperTest
    {
        [Fact]
        public void ShouldUnmap()
        {
            // Arrange
            var date = new DateTime();
            var dto = new PatientDto
            {
                Id = 12,
                Name = "Stefan",
                Sex = "Male",
                Pesel = "12345678901",
                Conditions = new[]
                {
                    new ConditionDto { Type = 1, DiagnosisDate = date },
                    new ConditionDto { Type = 2, DiagnosisDate = date.AddDays(8) }
                }
            };

            // Act
            var obj = dto.UnMap();

            // Assert
            obj.Id.Should().Be(12);
            obj.Name.Should().Be("Stefan");
            obj.Pesel.Should().Be("12345678901");
            obj.Sex.Should().Be(Sex.Male);
            obj.Conditions.Should().ContainInOrder(
                new Condition { Type = 1, DiagnosisDate = date },
                new Condition { Type = 2, DiagnosisDate = date.AddDays(8) });
        }

        [Fact]
        public void ShouldMap()
        {
            // Arrange
            var date = new DateTime();
            var obj = new Patient
            {
                Id = 12,
                Name = "Stefan",
                Pesel = "12345678901",
                Sex = Sex.Male,
                Conditions = new List<Condition>(new[]
                {
                    new Condition { Type = 1, DiagnosisDate = date },
                    new Condition { Type = 2, DiagnosisDate = date.AddDays(8) }
                })
            };

            // Act
            var dto = obj.Map();

            // Assert
            dto.Id.Should().Be(12);
            dto.Name.Should().Be("Stefan");
            dto.Sex.Should().Be("Male");
            dto.Conditions.Should().ContainInOrder(
                new ConditionDto { Type = 1, DiagnosisDate = date },
                new ConditionDto { Type = 2, DiagnosisDate = date.AddDays(8) });
        }
    }
}