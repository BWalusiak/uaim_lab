using System.Collections.Generic;

namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public IEnumerable<int> Specializations { get; set; }
        public string Name { get; set; }
    }
}