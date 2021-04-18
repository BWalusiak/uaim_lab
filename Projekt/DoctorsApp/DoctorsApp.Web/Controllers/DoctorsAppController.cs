namespace DoctorsApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dtos;
    using Application.Queries;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class DoctorsAppController : ControllerBase
    {
        private readonly IDoctorsQueryHandler _doctorsQueryHandler;
        private readonly IPatientsQueryHandler _patientsQueryHandler;
        private readonly ISelectorQueryHandler _selectorQueryHandler;

        public DoctorsAppController(IDoctorsQueryHandler doctorsQueryHandler,
            IPatientsQueryHandler patientsQueryHandler, ISelectorQueryHandler selectorQueryHandler)
        {
            _doctorsQueryHandler = doctorsQueryHandler;
            _patientsQueryHandler = patientsQueryHandler;
            _selectorQueryHandler = selectorQueryHandler;
        }

        [HttpGet("patients")]
        public async Task<IEnumerable<PatientDto>> GetAllPatient()
        {
            return await _patientsQueryHandler.GetAllPatient();
        }

        [HttpGet("patient/{id:int}")]
        public async Task<PatientDto> GetPatientById(int id)
        {
            return await _patientsQueryHandler.GetPatientById(id);
        }

        [HttpGet("patient/condition/{condition:int}")]
        public async Task<IEnumerable<PatientDto>> GetPatientsBySpecialization(int condition)
        {
            return await _patientsQueryHandler.GetPatientsByCondition(condition);
        }

        [HttpGet("patient/pesel/{pesel}")]
        public async Task<PatientDto> GetPatientByPesel(string pesel)
        {
            return await _patientsQueryHandler.GetPatientByPesel(pesel);
        }

        [HttpPost("patient")]
        public void AddPatient(PatientDto patientDto)
        {
            _patientsQueryHandler.AddPatient(patientDto);
        }


        [HttpGet("doctors")]
        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            return await _doctorsQueryHandler.GetAllDoctors();
        }

        [HttpGet("doctor/{id:int}")]
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            return await _doctorsQueryHandler.GetDoctorById(id);
        }

        [HttpGet("doctor/specialization/{specialization:int}")]
        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int specialization)
        {
            return await _doctorsQueryHandler.GetDoctorsBySpecialization(specialization);
        }

        [HttpGet("doctor/pesel/{pesel}")]
        public async Task<DoctorDto> GetDoctorByPesel(string pesel)
        {
            return await _doctorsQueryHandler.GetDoctorByPesel(pesel);
        }

        [HttpPost("doctor")]
        public void AddDoctor(DoctorDto doctorDto)
        {
            _doctorsQueryHandler.AddDoctor(doctorDto);
        }


        [HttpGet("doctor/{id:int}/can-treat")]
        public async Task<IEnumerable<PatientDto>> GetPatientsThatDoctorCanTreat(int id)
        {
            return await _selectorQueryHandler.GetPatientsThatDoctorCanTreat(id);
        }

        [HttpGet("doctor-patient-matches")]
        public async Task<IEnumerable<PatientDoctorDto>> GetBestPatientsByDoctorId()
        {
            return await _selectorQueryHandler.GetBestPatientDoctorMatches();
        }
    }
}