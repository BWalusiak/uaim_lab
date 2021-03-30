namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IExaminationRoomsServiceClient _examinationRoomsServiceClient;
        private readonly IDoctorsServiceClient _doctorsServiceClient;

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient,
            IDoctorsServiceClient doctorsServiceClient)
        {
            _examinationRoomsServiceClient = examinationRoomsServiceClient;
            _doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<IEnumerable<MatchDto>> GetExaminationRoomsSelectionAsync()
        {
            var doctors = (await _doctorsServiceClient.GetAllDoctorsAsync()).ToList();
            var rooms = (await _examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).ToList();

            var matches = MatchDoctorsRooms(doctors, rooms);
            return await Task.FromResult(matches);
        }

        private static IEnumerable<MatchDto> MatchDoctorsRooms(List<DoctorDto> doctorDtos,
            List<ExaminationRoomDto> examinationRoomDtos)
        {
            var matches = new List<MatchDto>();

            doctorDtos.ForEach(it =>
            {
                var bestRoom = GetBestRoom(it, examinationRoomDtos);
                if (bestRoom != null)
                {
                    matches.Add(new MatchDto(it, bestRoom));
                    examinationRoomDtos.Remove(bestRoom);
                }
            });

            return matches;
        }

        private static ExaminationRoomDto GetBestRoom(DoctorDto doctorDto, List<ExaminationRoomDto> roomDtos)
        {
            ExaminationRoomDto bestRoom = null;
            int intersections = 0;
            foreach (var roomDto in roomDtos)
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

    public interface IExaminationRoomsSelectorHandler
    {
        Task<IEnumerable<MatchDto>> GetExaminationRoomsSelectionAsync();
    }
}