using System.Collections.Generic;

namespace ExaminationRooms.Web.Application.Dtos
{
    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }
    }
}
