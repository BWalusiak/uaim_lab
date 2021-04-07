namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;

    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }

        protected bool Equals(ExaminationRoomDto other)
        {
            return Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ExaminationRoomDto) obj);
        }

        public override int GetHashCode()
        {
            return (Number != null ? Number.GetHashCode() : 0);
        }
    }
}
