namespace PatientsData.Infrastructure.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class Patient
    {
        public Patient(int id, string name, Sex sex, string pesel, List<Condition> conditions)
        {
            Id = id;
            Name = name;
            Sex = sex;
            PESEL = pesel;
            Conditions = conditions;
        }

        public Patient()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public string PESEL { get; set; }

        public List<Condition> Conditions { get; set; }
    }
}