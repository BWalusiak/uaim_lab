namespace PatientsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLogic.Matchers;
    using DataServiceClients;
    using DoctorsData.Infrastructure.Models;
    using Infrastrucutre.Models;
    using PatientsData.Infrastructure.Models;

    public class PatientsQueryHandler : IPatientsQueryHandler
    {
        private readonly IDoctorsDataServiceClient _doctorsDataServiceClient;
        private readonly IPatientsDataServiceClient _patientsDataServiceClient;

        public PatientsQueryHandler(IPatientsDataServiceClient patientsDataServiceClient,
            IDoctorsDataServiceClient doctorsDataServiceClient)
        {
            _patientsDataServiceClient = patientsDataServiceClient;
            _doctorsDataServiceClient = doctorsDataServiceClient;
        }

        public void AddPatient(Patient patient)
        {
            _patientsDataServiceClient.AddPatient(patient);
        }

        public Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return _patientsDataServiceClient.GetAllPatientsAsync();
        }

        public Task<IEnumerable<Patient>> GetAllPatientsByConditionIdAsync(int type)
        {
            return _patientsDataServiceClient.GetAllByConditionId(type);
        }

        public Task<Patient> GetByIdAsync(int id)
        {
            return _patientsDataServiceClient.GetPatientById(id);
        }

        public Task<Patient> GetByPeselAsync(string pesel)
        {
            return _patientsDataServiceClient.GetPatientByPesel(pesel);
        }

        public Doctor GetBestDoctorByPatientId(int id)
        {
            var patient = _patientsDataServiceClient.GetPatientById(id).Result;
            var doctors = _doctorsDataServiceClient.GetDoctorsBySpecializationId(patient.Conditions.First().Type).Result;
            var matcher = new BestDoctorMatcher(patient, doctors);
            return matcher.GetBestDoctor();
        }
    }

    public interface IPatientsQueryHandler
    {
        void AddPatient(Patient patient);

        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<IEnumerable<Patient>> GetAllPatientsByConditionIdAsync(int type);
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> GetByPeselAsync(string pesel);

        Doctor GetBestDoctorByPatientId(int id);
    }
}