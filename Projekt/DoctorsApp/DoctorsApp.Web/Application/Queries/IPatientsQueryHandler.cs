namespace DoctorsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface IPatientsQueryHandler
    {
        public Task<IEnumerable<PatientDto>> GetAllPatient();

        public Task<PatientDto> GetPatientById(int id);

        public Task<IEnumerable<PatientDto>> GetPatientsByCondition(int condition);

        public Task<PatientDto> GetPatientByPesel(string pesel);

        public void AddPatient(PatientDto patientDto);
    }
}