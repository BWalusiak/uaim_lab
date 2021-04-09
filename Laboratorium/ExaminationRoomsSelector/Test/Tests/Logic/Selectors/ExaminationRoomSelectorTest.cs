namespace ExaminationRoomsSelector.Test.Tests.Logic.Selectors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Providers;
    using Web.Application.Dtos;
    using Web.Logic.Selection;
    using Xunit;

    public class ExaminationRoomSelectorTest
    {
        private readonly IEnumerable<DoctorDto> _doctors;
        private readonly IEnumerable<ExaminationRoomDto> _rooms;


        public ExaminationRoomSelectorTest()
        {
            _doctors = DoctorDtoProvider.Faker.GenerateLazy(10);
            _rooms = ExaminationRoomDtoProvider.Faker.GenerateLazy(10);
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullExaminationRoomEnumerable()
        {
            // Arrange & Act
            // ReSharper disable once ObjectCreationAsStatement
            Action act = () => new ExaminationRoomSelector(null, _doctors);

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*examinationRooms*");
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullDoctorsEnumerable()
        {
            // Arrange & Act
            // ReSharper disable once ObjectCreationAsStatement
            Action act = () => new ExaminationRoomSelector(_rooms, null);

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*doctors*");
        }

        [Fact]
        public void ShouldGenerateUniqueDoctorRoomCombinations()
        {
            // Arrange
            var selector = new ExaminationRoomSelector(_rooms, _doctors);

            // Act 
            var matches = selector.MatchDoctorsRooms();

            // Assert
            var matchDtos = matches.ToList();
            matchDtos.Should().OnlyHaveUniqueItems(o => o.Doctor.Id);
            matchDtos.Should().OnlyHaveUniqueItems(o => o.ExaminationRoom.Number);
        }

        [Theory]
        [MemberData(nameof(GetPredefinedTestData), 3)]
        public void ShouldNotMissAnyExaminationRoomAndDoctorPairs(IEnumerable<ExaminationRoomDto> rooms,
            IEnumerable<DoctorDto> doctors, int count)
        {
            // Arrange
            var selector = new ExaminationRoomSelector(rooms, doctors);

            // Act
            var matches = selector.MatchDoctorsRooms();

            // Assert
            matches.Should().HaveCount(count);
        }

        public static IEnumerable<object[]> GetPredefinedTestData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[]
                {
                    new[]
                    {
                        new ExaminationRoomDto {Number = "101", Certifications = new[] {1, 2, 3}},
                        new ExaminationRoomDto {Number = "102", Certifications = new[] {5, 6, 7}},
                        new ExaminationRoomDto {Number = "103", Certifications = new[] {8, 9, 10}}
                    },
                    new[]
                    {
                        new DoctorDto {Id = 1, Name = "Jan", Specializations = new[] {1, 2, 3}},
                        new DoctorDto {Id = 1, Name = "Adam", Specializations = new[] {4, 5, 6}},
                        new DoctorDto {Id = 1, Name = "Maciek", Specializations = new[] {8, 9, 10}}
                    },
                    3
                },
                new object[]
                {
                    new[]
                    {
                        new ExaminationRoomDto {Number = "101", Certifications = new[] {2, 3}},
                        new ExaminationRoomDto {Number = "102", Certifications = new[] {5, 6, 7}},
                        new ExaminationRoomDto {Number = "103", Certifications = new[] {8, 9, 10}}
                    },
                    new[]
                    {
                        new DoctorDto {Id = 1, Name = "Marcin", Specializations = new[] {1}},
                        new DoctorDto {Id = 1, Name = "Adam", Specializations = new[] {4, 5, 6}},
                        new DoctorDto {Id = 1, Name = "Maciek", Specializations = new[] {8, 9, 10}}
                    },
                    2
                },
                new object[]
                {
                    new[]
                    {
                        new ExaminationRoomDto {Number = "101", Certifications = new[] {1, 2, 3}},
                        new ExaminationRoomDto {Number = "102", Certifications = new[] {5, 6, 7}},
                        new ExaminationRoomDto {Number = "103", Certifications = new[] {8, 9, 10}}
                    },
                    new[]
                    {
                        new DoctorDto {Id = 1, Name = "Jan", Specializations = new[] {11, 21, 31}},
                        new DoctorDto {Id = 1, Name = "Adam", Specializations = new[] {41, 51, 61}},
                        new DoctorDto {Id = 1, Name = "Maciek", Specializations = new[] {81, 91, 101}}
                    },
                    0
                }
            };
            return allData.Take(numTests);
        }

        [Fact(Timeout = 100)]
        public static async Task ShouldNotTimeOutWhenProcessingLargeAmountsOfData()
        {
            // Arrange
            var doctors = DoctorDtoProvider.Faker.Generate(1000);
            var rooms = ExaminationRoomDtoProvider.Faker.Generate(1000);

            var selector = new ExaminationRoomSelector(rooms, doctors);

            // Act 
            var matches = selector.MatchDoctorsRooms();

            // Assert
            var matchDtos = matches.ToList();
            matchDtos.Should().OnlyHaveUniqueItems(o => o.Doctor.Id);
            matchDtos.Should().OnlyHaveUniqueItems(o => o.ExaminationRoom.Number);
        }
    }
}