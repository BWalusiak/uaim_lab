namespace PatientsApp.Infrastrucutre.Models
{
    using System.Collections.Generic;
    using DoctorsData.Infrastructure.Models;
    using PatientsData.Infrastructure.Models;

    public class Doctor
    {
        public Doctor(int id, string name, Sex sex, string pesel, List<Specialization> specializations)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Pesel = pesel;
            Specializations = specializations;
        }

        public Doctor()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public string Pesel { get; set; }

        public List<Specialization> Specializations { get; set; }
    }
}