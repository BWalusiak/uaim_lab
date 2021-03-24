using System.Collections.Generic;
using DoctorWeb.Applictaion.Dtos;

namespace DoctorWeb.Applictaion.Queries
{
    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}