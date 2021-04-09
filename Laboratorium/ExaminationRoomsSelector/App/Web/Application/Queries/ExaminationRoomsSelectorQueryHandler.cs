namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;
    using Logic.Selection;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IDoctorsServiceClient _doctorsServiceClient;
        private readonly IExaminationRoomsServiceClient _examinationRoomsServiceClient;

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

            var selector = new ExaminationRoomSelector(rooms, doctors);
            var matches = selector.MatchDoctorsRooms();
            return await Task.FromResult(matches);
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            _doctorsServiceClient.AddDoctor(doctorDto);
        }
    }

    public interface IExaminationRoomsSelectorHandler
    {
        Task<IEnumerable<MatchDto>> GetExaminationRoomsSelectionAsync();
        void AddDoctor(DoctorDto doctorDto);
    }
}