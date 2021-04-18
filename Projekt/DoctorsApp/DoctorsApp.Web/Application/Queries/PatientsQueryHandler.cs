namespace DoctorsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;

    public class PatientsQueryHandler : IPatientsQueryHandler
    {
        private readonly IPatientsDataServiceClient _patientsDataServiceClient;

        public PatientsQueryHandler(IPatientsDataServiceClient patientsDataServiceClient)
        {
            _patientsDataServiceClient = patientsDataServiceClient;
        }

        public Task<IEnumerable<PatientDto>> GetAllPatient()
        {
            return _patientsDataServiceClient.GetAllPatients();
        }

        public Task<PatientDto> GetPatientById(int id)
        {
            return _patientsDataServiceClient.GetPatientById(id);
        }

        public Task<IEnumerable<PatientDto>> GetPatientsByCondition(int condition)
        {
            return _patientsDataServiceClient.GetPatientsByCondition(condition);
        }

        public Task<PatientDto> GetPatientByPesel(string pesel)
        {
            return _patientsDataServiceClient.GetPatientByPesel(pesel);
        }


        public void AddPatient(PatientDto patientDto)
        {
            _patientsDataServiceClient.AddPatient(patientDto);
        }
    }
}