namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        public IEnumerable<DoctorDto> GetAllDoctors()
        {
            return new List<DoctorDto> { new DoctorDto()};
        }
    }
}
