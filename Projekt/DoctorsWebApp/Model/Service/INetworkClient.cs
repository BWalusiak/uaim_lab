namespace Model.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;

    public interface INetworkClient
    {
        Task<List<DoctorData>> GetAllDoctors();

        Task<List<MatchData>> GetMatches();

        Task<List<MatchData>> GetSexMatches();

        Task<List<PatientData>> GetAllPatients();

        void AddPatient(PatientData patient);

        void AddDoctor(DoctorData patient);

        void DeletePatientById(int id);

        void DeletePatientByPesel(string pesel);

        void DeleteDoctorById(int id);

        void DeleteDoctorByPesel(string pesel);
    }
}