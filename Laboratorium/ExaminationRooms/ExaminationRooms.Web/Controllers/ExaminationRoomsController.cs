using ExaminationRooms.Web.Application.Dtos;
using ExaminationRooms.Web.Application.Queries;

namespace ExaminationRooms.Web.Controllers
{
    using ExaminationRooms.Domain;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class ExaminationRoomsController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsController> _logger;
        private readonly IExaminationRoomQueriesHandler _examinationRoomQueriesHandler;

        public ExaminationRoomsController(ILogger<ExaminationRoomsController> logger, IExaminationRoomQueriesHandler examinationRoomQueriesHandler)
        {
            this._logger = logger;
            this._examinationRoomQueriesHandler = examinationRoomQueriesHandler;
    }

        [HttpGet("examination-rooms")]
        public IEnumerable<ExaminationRoomDto> GetAll()
        {
            return _examinationRoomQueriesHandler.GetAll();
        }

        [HttpGet("examination-room")]
        public IEnumerable<ExaminationRoomDto> GetBySpecialization([FromQuery] int certificationType)
        {
            return _examinationRoomQueriesHandler.GetByCertificationType(certificationType);
        }
    }
}
