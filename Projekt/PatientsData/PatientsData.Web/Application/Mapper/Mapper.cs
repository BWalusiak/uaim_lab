namespace PatientsData.Web.Application.Mapper
{
    using System;
    using System.Linq;
    using Domain.Models;
    using Dtos;

    public static class Mapper
    {
        public static PatientDto Map(this Patient patient)
        {
            if (patient == null)
                return null;

            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Sex = patient.Sex.ToString(),
                Pesel = patient.Pesel,
                Conditions = patient?.Conditions.Select(c => new ConditionDto
                    {Type = c.Type, DiagnosisDate = c.DiagnosisDate.Date}).ToList()
            };
        }

        public static Patient UnMap(this PatientDto patientDto)
        {
            if (patientDto == null)
                return null;

            return new Patient
            {
                Id = patientDto.Id,
                Name = patientDto.Name,
                Sex = Enum.Parse<Sex>(patientDto.Sex),
                Pesel = patientDto.Pesel,
                Conditions = patientDto?.Conditions.Select(c => new Condition
                    {Type = c.Type, DiagnosisDate = c.DiagnosisDate}).ToList()
            };
        }
    }
}