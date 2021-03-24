using System.Linq;
using DoctorWeb.Applictaion.Dtos;
using MyLib.Models;

namespace DoctorWeb.Applictaion.Mapper
{
    public static class Mapper
    {
        public static DoctorDto Map(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorDto
            {
                Name = doctor.Name,
                Id = doctor.Id,
                Specializations = doctor?.Specializations
            };
        }
    }
}