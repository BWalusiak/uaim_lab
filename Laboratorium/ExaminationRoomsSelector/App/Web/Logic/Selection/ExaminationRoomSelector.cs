namespace ExaminationRoomsSelector.Web.Logic.Selection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Dtos;
    using Utils;

    public class ExaminationRoomSelector : IExaminationRoomSelector
    {
        private readonly IEnumerable<DoctorDto> _doctors;
        private readonly IEnumerable<ExaminationRoomDto> _examinationRooms;

        public ExaminationRoomSelector(IEnumerable<ExaminationRoomDto> examinationRooms, IEnumerable<DoctorDto> doctors)
        {
            _examinationRooms = examinationRooms ?? throw new ArgumentNullException(nameof(examinationRooms));
            _doctors = doctors ?? throw new ArgumentNullException(nameof(doctors));
        }

        public IEnumerable<MatchDto> MatchDoctorsRooms()
        {
            var matches = new List<MatchDto>();
            var rooms = new List<ExaminationRoomDto>(_examinationRooms);
            _doctors.ForEach(it =>
            {
                var bestRoom = GetBestRoom(it, rooms);
                if (bestRoom != null)
                {
                    matches.Add(new MatchDto(it, bestRoom));
                    rooms.Remove(bestRoom);
                }
            });

            return matches;
        }

        private ExaminationRoomDto GetBestRoom(DoctorDto doctorDto, IEnumerable<ExaminationRoomDto> rooms)
        {
            ExaminationRoomDto bestRoom = null;
            var intersections = 0;
            foreach (var roomDto in rooms)
            {
                var count = roomDto.Certifications.Intersect(doctorDto.Specializations).ToList().Count;
                if (count > intersections)
                {
                    intersections = count;
                    bestRoom = roomDto;
                }
            }

            return bestRoom;
        }
    }

    internal interface IExaminationRoomSelector
    {
        public IEnumerable<MatchDto> MatchDoctorsRooms();
    }
}