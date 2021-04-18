namespace DoctorsData.Application.Queries
{
    using System.Collections.Generic;
    using Dtos;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetByType(int type);
        DoctorDto GetById(int id);
        DoctorDto GetByPesel(string pesel);

        void AddDoctor(DoctorDto doctorDto);
    }
}