namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;

    public class DoctorDto
    {
        public int Id { get; set; }
        public IEnumerable<int> Specializations { get; set; }
        public string Name { get; set; }

        protected bool Equals(DoctorDto other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DoctorDto) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}