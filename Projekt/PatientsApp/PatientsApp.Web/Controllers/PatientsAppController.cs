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

        [HttpGet("doctors")]
        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            var doctors = await _patientsQueryHandler.GetAllDoctorsAsync();
            return doctors.Select(doctor => doctor.Map());
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

        [HttpGet("patient/{id:int}/best-doctor-sex")]
        public DoctorDto GetBestDoctorMatchSexByPatientId(int id)
        {
            var doctor = _patientsQueryHandler.GetBestDoctorMatchSexByPatientId(id);
            return doctor.Map();
        }


        [HttpPost("patient")]
        public void AddPatient(PatientDto patientDto)
        {
            _patientsQueryHandler.AddPatient(patientDto.UnMap());
        }

        [HttpDelete("patient/{id:int}")]
        public void DeletePatient(int id)
        {
            _patientsQueryHandler.DeletePatient(id);
        }

        [HttpDelete("patient/pesel/{id:int}")]
        public void DeletePatient(string pesel)
        {
            _patientsQueryHandler.DeletePatient(pesel);
        }
    }
}