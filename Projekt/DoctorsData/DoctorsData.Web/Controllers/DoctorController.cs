namespace DoctorsData.Controllers
{
    using System.Collections.Generic;
    using Application.Dtos;
    using Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorQueriesHandler _doctorQueriesHandler;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(ILogger<DoctorController> logger, IDoctorQueriesHandler doctorQueriesHandler)
        {
            _logger = logger;
            _doctorQueriesHandler = doctorQueriesHandler;
        }

        [HttpGet("doctors")]
        public IEnumerable<DoctorDto> GetAll()
        {
            return _doctorQueriesHandler.GetAll();
        }

        [HttpGet("select-specialization")]
        public IEnumerable<DoctorDto> GetByType(int type)
        {
            return _doctorQueriesHandler.GetByType(type);
        }

        [HttpGet("doctor-id")]
        public DoctorDto GetById(int id)
        {
            return _doctorQueriesHandler.GetById(id);
        }

        [HttpGet("doctor-pesel")]
        public DoctorDto GetByPesel(string pesel)
        {
            return _doctorQueriesHandler.GetByPesel(pesel);
        }

        [HttpPost("add-doctor")]
        public void AddDoctor(DoctorDto doctorDto)
        {
            _doctorQueriesHandler.AddDoctor(doctorDto);
        }
    }
}