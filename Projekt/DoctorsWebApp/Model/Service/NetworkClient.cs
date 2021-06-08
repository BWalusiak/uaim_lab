namespace Model.Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Configuration;
    using Data;
    using Utilities;

    public class NetworkClient : INetworkClient
    {
        private readonly ServiceClient _serviceClient;

        public NetworkClient(ServiceConfiguration configuration)
        {
            _serviceClient = new ServiceClient(configuration.BackendUrl);
        }

        public void AddPatient(PatientData patient)
        {
            var callUri = "patient";
            _ = _serviceClient.CallWebServiceAsync<PatientData>(callUri, patient);
        }

        public void AddDoctor(DoctorData patient)
        {
            var callUri = "doctor";
            _ = _serviceClient.CallWebServiceAsync<DoctorData>(callUri, patient);
        }

        public void DeletePatientById(int id)
        {
            var callUri = $"patient/{id}";
            _ = _serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Delete, callUri);
        }

        public void DeletePatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            _ = _serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Delete, callUri);
        }

        public void DeleteDoctorById(int id)
        {
            var callUri = $"doctor/{id}";
            _ = _serviceClient.CallWebServiceAsync<DoctorData>(HttpMethod.Delete, callUri);
        }

        public void DeleteDoctorByPesel(string pesel)
        {
            var callUri = $"doctor/pesel/{pesel}";
            _ = _serviceClient.CallWebServiceAsync<DoctorData>(HttpMethod.Delete, callUri);
        }

        public Task<List<DoctorData>> GetAllDoctors()
        {
            const string callUri = "doctors";
            var allDoctors = _serviceClient.CallWebServiceAsync<List<DoctorData>>(HttpMethod.Get, callUri);
            return allDoctors;
        }

        public Task<List<MatchData>> GetMatches()
        {
            const string callUri = "doctor-patient-matches";
            var allMatches = _serviceClient.CallWebServiceAsync<List<MatchData>>(HttpMethod.Get, callUri);
            return allMatches;
        }

        public Task<List<MatchData>> GetSexMatches()
        {
            const string callUri = "doctor-patient-matches-with-sex";
            var allMatches = _serviceClient.CallWebServiceAsync<List<MatchData>>(HttpMethod.Get, callUri);
            return allMatches;
        }

        public Task<List<PatientData>> GetAllPatients()
        {
            const string callUri = "patients";
            var allPatients = _serviceClient.CallWebServiceAsync<List<PatientData>>(HttpMethod.Get, callUri);
            return allPatients;
        }
    }
}