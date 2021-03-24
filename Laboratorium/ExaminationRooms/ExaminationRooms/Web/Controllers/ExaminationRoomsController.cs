namespace ExaminationRooms.Web.Controllers
{
    using System.Collections.Generic;
    using Application.Dtos;
    using Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

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
