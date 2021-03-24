using System.Collections.Generic;
using ExaminationRooms.Web.Application.Dtos;

namespace ExaminationRooms.Web.Application.Queries
{
    public interface IExaminationRoomQueriesHandler
    {
        IEnumerable<ExaminationRoomDto> GetAll();
        IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType);
    }
}
