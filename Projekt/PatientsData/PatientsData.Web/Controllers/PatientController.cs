namespace PatientsData.Web.Controllers
{
    using System.Collections.Generic;
    using Application.Dtos;
    using Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientQueriesHandler _patientQueriesHandler;

        public PatientController(ILogger<PatientController> logger, IPatientQueriesHandler patientQueriesHandler)
        {
            _logger = logger;
            _patientQueriesHandler = patientQueriesHandler;
        }

        [HttpGet("patients")]
        public IEnumerable<PatientDto> GetAll()
        {
            return _patientQueriesHandler.GetAll();
        }

        [HttpGet("select-condition")]
        public IEnumerable<PatientDto> GetByType(int type)
        {
            return _patientQueriesHandler.GetByType(type);
        }

        [HttpGet("patient-id")]
        public PatientDto GetById(int id)
        {
            return _patientQueriesHandler.GetById(id);
        }

        [HttpGet("patient-pesel")]
        public PatientDto GetByPesel(string pesel)
        {
            return _patientQueriesHandler.GetByPesel(pesel);
        }

        [HttpPost("add-patient")]
        public void AddPatient(PatientDto patientDto)
        {
            _patientQueriesHandler.AddPatient(patientDto);
        }
    }
}