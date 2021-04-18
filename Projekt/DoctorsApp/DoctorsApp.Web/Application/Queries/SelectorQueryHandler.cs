namespace DoctorsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;
    using Logic.Selector;

    public class SelectorQueryHandler : ISelectorQueryHandler
    {
        private readonly IDoctorsDataServiceClient _doctorsDataServiceClient;
        private readonly IPatientsDataServiceClient _patientsQueryHandler;

        public SelectorQueryHandler(IDoctorsDataServiceClient doctorsDataServiceClient,
            IPatientsDataServiceClient patientsDataServiceClient)
        {
            _doctorsDataServiceClient = doctorsDataServiceClient;
            _patientsQueryHandler = patientsDataServiceClient;
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsThatDoctorCanTreat(int id)
        {
            var doctor = await _doctorsDataServiceClient.GetDoctorById(id);
            var patients = await _patientsQueryHandler.GetAllPatients();

            return PatientSelector.GetPatientsThatDoctorCanTreat(doctor, patients);
        }

        public async Task<IEnumerable<PatientDoctorDto>> GetBestPatientDoctorMatches()
        {
            var doctors = await  _doctorsDataServiceClient.GetAllDoctors();
            var patients = await _patientsQueryHandler.GetAllPatients();
            
            return PatientSelector.GetBestPatientDoctorMatches(doctors, patients);
        }
    }
}