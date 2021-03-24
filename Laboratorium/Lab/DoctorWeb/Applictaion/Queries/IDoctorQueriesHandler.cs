namespace DoctorWeb.Applictaion.Queries
{
    using System.Collections.Generic;
    using Dtos;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}