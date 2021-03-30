namespace ExaminationRooms.Domain.Aggregate
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using SeedWork;

    [XmlRoot("examinationRoom", IsNullable = false)]
    public class ExaminationRoom : Entity
    {
        public ExaminationRoom()
        {
        }

        public string Number { get; set; }
        
        public List<Certification> Certifications { get; set; }

        public ExaminationRoom(int id, string number) : base(id)
        {
            Number = number;
        }

        public ExaminationRoom(int id, string number, List<Aggregate.Certification> certifications) : this(id, number)
        {
            Certifications = certifications;
        }

        public void AddCertification(Aggregate.Certification certification)
        {
            Certifications.Add(certification);
        }
    }
}
