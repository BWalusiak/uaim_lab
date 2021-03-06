namespace DoctorsUwpFrontendClientApplication.Models
{
    using System.Collections.Generic;

    public class DoctorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Pesel { get; set; }

        public IEnumerable<SpecializationDto> Specializations { get; set; }

        public DoctorDto()
        {
            Name = "";
            Sex = "";
            Pesel = "";
            Specializations = new List<SpecializationDto>();
        }
    }
}