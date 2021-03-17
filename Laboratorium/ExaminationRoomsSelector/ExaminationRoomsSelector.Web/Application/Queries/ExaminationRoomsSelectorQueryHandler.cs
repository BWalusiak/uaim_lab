namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using ExaminationRoomsSelector.Web.Application.DataServiceClients;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IExaminationRoomsServiceClient _examinationRoomsServiceClient;
        private readonly IDoctorsServiceClient _doctorsServiceClient;

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient, IDoctorsServiceClient doctorsServiceClient)
        {
            _examinationRoomsServiceClient = examinationRoomsServiceClient;
            _doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<int> GetExaminationRoomsSelectionAsync()
        {  
            var doctors = await _doctorsServiceClient.GetAllDoctorsAsync();

            return (await _examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).Count();
        }
    }
}
