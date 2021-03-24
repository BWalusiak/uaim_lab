namespace Doctors.Web.Applictaion.Mapper
{
    using Dtos;
    using Infrastructure.Models;

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