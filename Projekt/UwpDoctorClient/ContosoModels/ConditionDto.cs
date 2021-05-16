namespace DoctorsApp.Web.Application.Dtos
{
    using System;

    public class ConditionDto
    {
        public int Type { get; set; }
        
        public DateTime DiagnosisDate { get; set; }

        public ConditionDto(int type, DateTime diagnosisDate)
        {
            Type = type;
            DiagnosisDate = diagnosisDate;
        }

        public override string ToString()
        {
            return $"{Type}-{DiagnosisDate}";
        }
    }
}