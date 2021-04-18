namespace DoctorsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;

    public class DoctorsQueryHandler : IDoctorsQueryHandler
    {
        private readonly IDoctorsDataServiceClient _doctorsDataServiceClient;

        public DoctorsQueryHandler(IDoctorsDataServiceClient doctorsDataServiceClient)
        {
            _doctorsDataServiceClient = doctorsDataServiceClient;
        }

        public Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            return _doctorsDataServiceClient.GetAllDoctors();
        }

        public Task<DoctorDto> GetDoctorById(int id)
        {
            return _doctorsDataServiceClient.GetDoctorById(id);
        }

        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int specialization)
        {
            return _doctorsDataServiceClient.GetDoctorsBySpecialization(specialization);
        }

        public Task<DoctorDto> GetDoctorByPesel(string pesel)
        {
            return _doctorsDataServiceClient.GetDoctorsByPesel(pesel);
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            _doctorsDataServiceClient.AddDoctor(doctorDto);
        }
    }
}