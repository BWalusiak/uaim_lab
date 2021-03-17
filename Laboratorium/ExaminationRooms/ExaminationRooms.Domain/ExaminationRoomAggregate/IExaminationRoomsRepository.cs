namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System.Collections.Generic;

    public interface IExaminationRoomsRepository
    {
        IEnumerable<ExaminationRoom> GetAll();
        IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType);
    }
}