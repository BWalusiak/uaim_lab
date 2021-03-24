namespace ExaminationRooms.Domain.Aggregate
{
    using System.Collections.Generic;
    using SeedWork;

    public class ExaminationRoom : Entity
    {
        public string Number { get; private set; }
        public IList<Aggregate.Certification> Certifications { get; private set; } = new List<Aggregate.Certification>();

        public ExaminationRoom(int id, string number) : base(id)
        {
            Number = number;
        }

        public ExaminationRoom(int id, string number, IList<Aggregate.Certification> certifications) : this(id, number)
        {
            Certifications = certifications;
        }

        public void AddCertification(Aggregate.Certification certification)
        {
            Certifications.Add(certification);
        }
    }
}
