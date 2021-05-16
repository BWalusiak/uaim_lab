namespace DoctorsApp.Web.Application.Dtos
{
    using System;

    public class SpecializationDto
    {
        public SpecializationDto(int type, DateTime certificationDate)
        {
            Type = type;
            CertificationDate = certificationDate;
        }

        public int Type { get; set; }
        
        public DateTime CertificationDate { get; set; }

        public override string ToString()
        {
            return $"{Type}-{CertificationDate}";
        }
    }
}