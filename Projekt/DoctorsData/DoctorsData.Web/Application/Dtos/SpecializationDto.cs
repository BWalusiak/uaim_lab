namespace DoctorsData.Application.Dtos
{
    using System;

    public class SpecializationDto
    {
        public int Type;
        public DateTime CertificationDate;

        protected bool Equals(SpecializationDto other)
        {
            return Type == other.Type && CertificationDate.Equals(other.CertificationDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((SpecializationDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, CertificationDate);
        }
    }
}