namespace Doctors.Infrastructure.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Web.Applictaion.Dtos;

    [XmlRoot("doctor", IsNullable = false)]
    public class Doctor : Person
    {
        public Doctor()
        {
        }

        public Doctor(int id, string name, List<int> specializations) : base(id, name)
        {
            Specializations = specializations;
        }

        public Doctor(DoctorDto doctorDto) : base(doctorDto.Id, doctorDto.Name)
        {
            Specializations = doctorDto.Specializations as List<int>;
        }


        [XmlArrayItem("Specialization")]
        public List<int> Specializations { get; set; }

        public override bool CanOperate()
        {
            return true;
        }

        public override string GetDescription()
        {
            return $"Dr {Name} of sex {Sex}";
        }
    }
}