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
        private readonly IExaminationRoomsSelectorHandler _examinationRoomsSelectorHandler;
        private readonly ILogger<ExaminationRoomsSelectorController> _logger;

        public ExaminationRoomsSelectorController(ILogger<ExaminationRoomsSelectorController> logger,
            IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler)
        {
            _logger = logger;
            _examinationRoomsSelectorHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("examination-rooms-selection")]
        public async Task<IEnumerable<MatchDto>> GetLaboratoryDiagnosticiansDetails()
        {
            return await _examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }

        [HttpPost("add-doctor")]
        public async void AddDoctor(DoctorDto doctorDto)
        {
            _examinationRoomsSelectorHandler.AddDoctor(doctorDto);
        }
    }
}