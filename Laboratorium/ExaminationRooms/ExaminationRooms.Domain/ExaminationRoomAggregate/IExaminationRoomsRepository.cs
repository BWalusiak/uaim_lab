namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IExaminationRoomsRepository
    {
        IEnumerable<ExaminationRoom> GetAll();
        IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType);
    }
}
