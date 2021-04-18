namespace PatientsData.Web.Application.Queries
{
    using System.Collections.Generic;
    using Dtos;

    public interface IPatientQueriesHandler
    {
        IEnumerable<PatientDto> GetAll();
        IEnumerable<PatientDto> GetByType(int type);
        PatientDto GetById(int id);
        PatientDto GetByPesel(string pesel);

        void AddPatient(PatientDto patientDto);
    }
}