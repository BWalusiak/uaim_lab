namespace PatientsApp.Web.Application.Dtos
{
    using System;

    public class ConditionDto
    {
        public int Type { get; set; }
        public DateTime DiagnosisDate { get; set; }

        protected bool Equals(ConditionDto other)
        {
            return Type == other.Type && DiagnosisDate.Equals(other.DiagnosisDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((ConditionDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, DiagnosisDate);
        }
    }
}