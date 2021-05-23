namespace DoctorsData.Domain.Models
{
    using System;

    public class Specialization
    {
        public int Type;
        public DateTime CertificationDate;

        protected bool Equals(Specialization other)
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
            return Equals((Specialization)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, CertificationDate);
        }
    }
}