namespace PatientsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLogic.Matchers;
    using DataServiceClients;
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

        public void DeletePatient(int id)
        {
            _patientsDataServiceClient.DeletePatient(id);
        }

        public void DeletePatient(string pesel)
        {
            _patientsDataServiceClient.DeletePatient(pesel);
        }

        public Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return _doctorsDataServiceClient.GetAllDoctors();
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

        public Doctor GetBestDoctorMatchSexByPatientId(int id)
        {
            var patient = _patientsDataServiceClient.GetPatientById(id).Result;
            var doctors = _doctorsDataServiceClient.GetDoctorsBySpecializationId(patient.Conditions.First().Type).Result;
            var matcher = new BestDoctorMatcher(patient, doctors);
            return matcher.GetBestDoctorSex();
        }
    }

}