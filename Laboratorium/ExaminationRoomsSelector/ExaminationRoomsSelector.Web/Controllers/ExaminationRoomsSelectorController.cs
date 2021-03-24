namespace ExaminationRoomsSelector.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dtos;
    using Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

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
        public async Task<IEnumerable<MatchDto>> GetLaboratoryDiagnosticiansDetails()
        {
            return await _examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }
    }
}
