using System.Collections.Generic;

namespace DoctorWeb.Applictaion.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public IEnumerable<int> Specializations { get; set; }
        public string Name { get; set; }
    }
}