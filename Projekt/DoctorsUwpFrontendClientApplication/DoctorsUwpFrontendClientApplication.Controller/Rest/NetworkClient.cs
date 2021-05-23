namespace DoctorsUwpFrontendClientApplication.Controller.Rest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class NetworkClient : INetworkClient
    {
        private readonly HttpHelper _http;

        public NetworkClient(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        // Doctor Queries
        public Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            return _http.GetAsync<IEnumerable<DoctorDto>>("doctors");
        }

        public Task<DoctorDto> GetDoctorById(int id)
        {
            return _http.GetAsync<DoctorDto>($"doctor/{id}");
        }

        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int specialization)
        {
            return _http.GetAsync<IEnumerable<DoctorDto>>($"doctor/specialization/{specialization}");
        }

        public Task<DoctorDto> GetDoctorByPesel(string pesel)
        {
            return _http.GetAsync<DoctorDto>($"doctor/pesel/{pesel}");
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            _http.PostAsyncNoR("doctor", doctorDto);
        }

        public void DeleteDoctor(int id)
        { 
            _http.DeleteAsyncNoGuid($"doctor/{id}");
        }

        // Patient Queries
        public Task<IEnumerable<PatientDto>> GetAllPatient()
        {
            return _http.GetAsync<IEnumerable<PatientDto>>("patients");
        }

        public Task<PatientDto> GetPatientById(int id)
        {
            return _http.GetAsync<PatientDto>($"patient/{id}");
        }

        public Task<IEnumerable<PatientDto>> GetPatientsByCondition(int condition)
        {
            return _http.GetAsync<IEnumerable<PatientDto>>($"patient/condition/{condition}");
        }

        public Task<PatientDto> GetPatientByPesel(string pesel)
        {
            return _http.GetAsync<PatientDto>($"patient/pesel/{pesel}");
        }

        public void AddPatient(PatientDto patientDto)
        {
            _http.PostAsyncNoR("patient", patientDto);
        }

        public void RemovePatientById(int id)
        {
            _http.DeleteAsyncNoGuid($"patient/{id}");
        }

        public void RemovePatientByPesel(string pesel)
        {
            _http.DeleteAsyncNoGuid($"patient/pesel/{pesel}");
        }

        public Task<IEnumerable<PatientDto>> GetPatientsThatDoctorCanTreat(int id)
        {
            return _http.GetAsync<IEnumerable<PatientDto>>($"doctor/{id}/can-treat");
        }


        // Match Queries
        public Task<IEnumerable<PatientDoctorDto>> GetBestPatientDoctorMatches()
        {
            return _http.GetAsync<IEnumerable<PatientDoctorDto>>("doctor-patient-matches");
        }

        public Task<IEnumerable<PatientDoctorDto>> GetMatchDoctorSexWithPatientSex()
        {
            return _http.GetAsync<IEnumerable<PatientDoctorDto>>("doctor-patient-matches-with-sex");
        }
    }
}
