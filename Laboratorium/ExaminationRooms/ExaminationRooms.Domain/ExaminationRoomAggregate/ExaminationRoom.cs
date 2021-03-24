namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System.Collections.Generic;
    using SeedWork;

    public class ExaminationRoom : Entity
    {
        public string Number { get; private set; }
        public IList<Certification> Certifications { get; private set; } = new List<Certification>();

        public ExaminationRoom(int id, string number) : base(id)
        {
            Number = number;
        }

        public ExaminationRoom(int id, string number, IList<Certification> certifications) : this(id, number)
        {
            Certifications = certifications;
        }

        public void AddCertification(Certification certification)
        {
            Certifications.Add(certification);
        }
    }
}
