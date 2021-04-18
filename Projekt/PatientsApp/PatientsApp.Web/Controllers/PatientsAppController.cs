namespace PatientsApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Dtos;
    using Application.Queries;
    using Mapper;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class PatientsAppController : ControllerBase
    {
        private readonly IPatientsQueryHandler _patientsQueryHandler;

        public PatientsAppController(IPatientsQueryHandler patientsQueryHandler)
        {
            _patientsQueryHandler = patientsQueryHandler;
        }

        [HttpGet("patients")]
        public async Task<IEnumerable<PatientDto>> GetAllPatients()
        {
            var patients = await _patientsQueryHandler.GetAllPatientsAsync();
            return patients.Select(patient => patient.Map());
        }

        [HttpGet("patient/condition/{type:int}")]
        public async Task<IEnumerable<PatientDto>> GetAllPatientsByCondition(int type)
        {
            var patientsByCondition = await _patientsQueryHandler.GetAllPatientsByConditionIdAsync(type);
            return patientsByCondition?.Select(patient => patient.Map());
        }

        [HttpGet("patient/{id:int}")]
        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var patient = await _patientsQueryHandler.GetByIdAsync(id);
            return patient.Map();
        }

        [HttpGet("patient/pesel/{pesel}")]
        public async Task<PatientDto> GetByPeselAsync(string pesel)
        {
            var patient = await _patientsQueryHandler.GetByPeselAsync(pesel);
            return patient.Map();
        }

        [HttpGet("patient/{id:int}/best-doctor")]
        public DoctorDto GetBestDoctorByPatientId(int id)
        {
            var doctor = _patientsQueryHandler.GetBestDoctorByPatientId(id);
            return doctor.Map();
        }


        [HttpPost("patient")]
        public void AddPatient(PatientDto patientDto)
        {
            _patientsQueryHandler.AddPatient(patientDto.UnMap());
        }
    }
}