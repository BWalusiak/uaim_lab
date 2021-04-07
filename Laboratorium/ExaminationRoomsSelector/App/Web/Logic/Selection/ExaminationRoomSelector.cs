namespace ExaminationRoomsSelector.Web.Logic.Selection
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Dtos;
    using Utils;

    public class ExaminationRoomSelector : IExaminationRoomSelector
    {
        private IEnumerable<DoctorDto> _doctors;
        private ICollection<ExaminationRoomDto> _examinationRooms;

        public ExaminationRoomSelector(ICollection<ExaminationRoomDto> examinationRooms, IEnumerable<DoctorDto> doctors)
        {
            _examinationRooms = examinationRooms;
            _doctors = doctors;
        }

        public IEnumerable<MatchDto> MatchDoctorsRooms()
        {
            var matches = new List<MatchDto>();

            _doctors.ForEach(it =>
            {
                var bestRoom = GetBestRoom(it);
                if (bestRoom != null)
                {
                    matches.Add(new MatchDto(it, bestRoom));
                    _examinationRooms.Remove(bestRoom);
                }
            });

            return matches;
        }

        public ExaminationRoomDto GetBestRoom(DoctorDto doctorDto)
        {
            ExaminationRoomDto bestRoom = null;
            int intersections = 0;
            foreach (var roomDto in _examinationRooms)
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

    interface IExaminationRoomSelector
    {
        public IEnumerable<MatchDto> MatchDoctorsRooms();
        public ExaminationRoomDto GetBestRoom(DoctorDto doctorDto);
    }
}