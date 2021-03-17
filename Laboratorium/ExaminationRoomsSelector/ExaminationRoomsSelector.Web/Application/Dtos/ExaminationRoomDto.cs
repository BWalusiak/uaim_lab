namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;

    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<string> Certifications { get; set; }
    }
}
