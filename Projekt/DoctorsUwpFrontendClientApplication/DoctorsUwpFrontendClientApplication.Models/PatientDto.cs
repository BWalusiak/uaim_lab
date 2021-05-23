namespace DoctorsUwpFrontendClientApplication.Models
{
    using System.Collections.Generic;

    public class PatientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Pesel { get; set; }

        public IEnumerable<ConditionDto> Conditions { get; set; }

        public PatientDto()
        {
            Name = "";
            Sex = "";
            Pesel = "";
            Conditions = new List<ConditionDto>();
        }
    }
}