namespace PatientsApp.Infrastrucutre.Models
{
    using System;

    public class Condition
    {
        public int Type;
        public DateTime DiagnosisDate;

        protected bool Equals(Condition other)
        {
            return Type == other.Type && DiagnosisDate.Equals(other.DiagnosisDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Condition)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, DiagnosisDate);
        }
    }
}