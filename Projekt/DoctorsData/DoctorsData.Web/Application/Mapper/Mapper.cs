namespace DoctorsData.Application.Mapper
{
    using System;
    using System.Linq;
    using Domain.Models;
    using Dtos;

    public static class Mapper
    {
        public static DoctorDto Map(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Sex = doctor.Sex.ToString(),
                Pesel = doctor.Pesel,
                Specializations = doctor?.Specializations.Select(c => new SpecializationDto
                { Type = c.Type, CertificationDate = c.CertificationDate.Date }).ToList()
            };
        }

        public static Doctor UnMap(this DoctorDto doctorDto)
        {
            if (doctorDto == null)
                return null;

            return new Doctor
            {
                Id = doctorDto.Id,
                Name = doctorDto.Name,
                Sex = Enum.Parse<Sex>(doctorDto.Sex),
                Pesel = doctorDto.Pesel,
                Specializations = doctorDto?.Specializations.Select(c => new Specialization
                { Type = c.Type, CertificationDate = c.CertificationDate }).ToList()
            };
        }
    }
}