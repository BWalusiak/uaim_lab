namespace ExaminationRooms.Web.Application.Queries
{
    using System.Collections.Generic;
    using Dtos;

    public interface IExaminationRoomQueriesHandler
    {
        IEnumerable<ExaminationRoomDto> GetAll();
        IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType);
    }
}
