namespace ExaminationRooms.Domain.Aggregate
{
    using System.Collections.Generic;

    public interface IExaminationRoomsRepository
    {
        IEnumerable<Aggregate.ExaminationRoom> GetAll();
        IEnumerable<Aggregate.ExaminationRoom> GetByCertificationType(int certificationType);
    }
}