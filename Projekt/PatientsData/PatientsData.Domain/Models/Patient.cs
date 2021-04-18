namespace PatientsData.Domain.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Patient", IsNullable = false)]
    public class Patient
    {
        public Patient(int id, string name, Sex sex, string pesel, List<Condition> conditions)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Pesel = pesel;
            Conditions = conditions;
        }

        public Patient()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public string Pesel { get; set; }

        public List<Condition> Conditions { get; set; }
    }
}