using ExaminationRoomsSelector.Web.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationRoomsSelector.Web.Controllers
{
    [ApiController]
    public class ExaminationRoomsSelectorController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsSelectorController> _logger;
        private readonly IExaminationRoomsSelectorHandler _examinationRoomsSelectorHandler;

        public ExaminationRoomsSelectorController(ILogger<ExaminationRoomsSelectorController> logger, IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler)
        {
            this._logger = logger;
            this._examinationRoomsSelectorHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("examination-rooms-selection")]
        public async Task<int> GetLaboratoryDiagnosticiansDetails()
        {
            return await _examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }
    }
}
