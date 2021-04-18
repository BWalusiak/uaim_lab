namespace DoctorsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface IDoctorsDataServiceClient
    {
        public Task<IEnumerable<DoctorDto>> GetAllDoctors();

        public Task<DoctorDto> GetDoctorById(int id);

        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int condition);

        public Task<DoctorDto> GetDoctorsByPesel(string pesel);

        public void AddDoctor(DoctorDto doctorDto);
    }
}