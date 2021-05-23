namespace DoctorsUwpFrontendClientApplication.Controller.Rest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface INetworkClient
    {
        // Doctor Queries
        public Task<IEnumerable<DoctorDto>> GetAllDoctors();

        public Task<DoctorDto> GetDoctorById(int id);

        public Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int specialization);

        public Task<DoctorDto> GetDoctorByPesel(string pesel);

        public void AddDoctor(DoctorDto doctorDto);

        public void DeleteDoctor(int id);

        // Patient Queries
        public Task<IEnumerable<PatientDto>> GetAllPatient();

        public Task<PatientDto> GetPatientById(int id);

        public Task<IEnumerable<PatientDto>> GetPatientsByCondition(int condition);

        public Task<PatientDto> GetPatientByPesel(string pesel);

        public void AddPatient(PatientDto patientDto);

        void RemovePatientById(int id);

        void RemovePatientByPesel(string pesel);

        public Task<IEnumerable<PatientDto>> GetPatientsThatDoctorCanTreat(int id);

        // Match Queries

        public Task<IEnumerable<PatientDoctorDto>> GetBestPatientDoctorMatches();

        public Task<IEnumerable<PatientDoctorDto>> GetMatchDoctorSexWithPatientSex();
    }
}
