namespace ExaminationRoomsSelector.Test.Logic.Selectors
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Web.Application.Dtos;
    using Web.Logic.Selection;
    using Xunit;

    public class ExaminationRoomSelectorTest
    {
        private IEnumerable<DoctorDto> _doctors;
        private IEnumerable<ExaminationRoomDto> _rooms;

        public ExaminationRoomSelectorTest()
        {
            _doctors = new[]
            {
                new DoctorDto {Id = 1, Name = "Johnson Borys", Specializations = new[] {1, 2, 3}},
                new DoctorDto {Id = 2, Name = "Borys Johnson", Specializations = new[] {3, 4, 5}},
                new DoctorDto {Id = 3, Name = "Adam Blake", Specializations = new[] {1, 2, 5}},
                new DoctorDto {Id = 4, Name = "Mathew Obama", Specializations = new[] {2, 4}},
            };
            _rooms = new[]
            {
                new ExaminationRoomDto {Number = "112", Certifications = new[] {1, 2, 5, 6}},
                new ExaminationRoomDto {Number = "B12", Certifications = new[] {1, 2, 3, 4, 5, 6, 7}}
            };
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullExaminationRoomEnumerable()
        {
            // Arrange & Act
            // ReSharper disable once ObjectCreationAsStatement
            Action act = () => new ExaminationRoomSelector(null, _doctors);

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().Which.Message.Should().Contain("examinationRooms");
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullDoctorsEnumerable()
        {
            // Arrange & Act
            // ReSharper disable once ObjectCreationAsStatement
            Action act = () => new ExaminationRoomSelector(_rooms, null);

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().Which.Message.Should().Contain("doctors");
        }
    }
}