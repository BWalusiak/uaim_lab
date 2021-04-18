namespace DoctorsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface IPatientsDataServiceClient
    {
        public Task<IEnumerable<PatientDto>> GetAllPatients();

        public Task<PatientDto> GetPatientById(int id);

        public Task<IEnumerable<PatientDto>> GetPatientsByCondition(int condition);

        public Task<PatientDto> GetPatientByPesel(string pesel);

        public void AddPatient(PatientDto patientDto);
    }
}