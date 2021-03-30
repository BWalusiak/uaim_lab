namespace Doctors.Web.Controllers
{
    using System.Collections.Generic;
    using Applictaion.Dtos;
    using Applictaion.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;
        private readonly IDoctorQueriesHandler _doctorQueriesHandler;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorQueriesHandler doctorQueriesHandler)
        {
            _logger = logger;
            _doctorQueriesHandler = doctorQueriesHandler;
        }

        [HttpPost("doctor")]
        public bool AddDoctor(DoctorDto doctorDto)
        {
            return _doctorQueriesHandler.AddDoctor(doctorDto);
        }

        [HttpGet("doctors")]
        public IEnumerable<DoctorDto> GetAll()
        {
            return _doctorQueriesHandler.GetAll();
        }

        [HttpGet("doctor")]
        public IEnumerable<DoctorDto> GetBySpecialization([FromQuery] int specialization)
        {
            return _doctorQueriesHandler.GetBySpecialization(specialization);
        }
    }
}