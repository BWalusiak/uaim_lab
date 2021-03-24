﻿using System.Collections.Generic;
using DoctorWeb.Applictaion.Dtos;
using DoctorWeb.Applictaion.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DoctorWeb.Controllers
{
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