namespace DoctorsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface IDoctorsQueryHandler
    {
        public Task<IEnumerable<DoctorDto>> GetAllDoctors();

        public Task<DoctorDto> GetDoctorById(int id);

        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int specialization);

        public Task<DoctorDto> GetDoctorByPesel(string pesel);

        public void AddDoctor(DoctorDto doctorDto);
    }
}