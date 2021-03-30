namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;

    public class DoctorDto
    {
        public int Id { get; set; }
        public IEnumerable<int> Specializations { get; set; }
        public string Name { get; set; }
    }
}