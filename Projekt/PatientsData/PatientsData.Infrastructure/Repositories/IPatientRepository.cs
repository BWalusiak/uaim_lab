namespace PatientsData.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using Domain.Models;

    public interface IPatientRepository
    {
        IEnumerable<Patient> GetByType(int type);
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        Patient GetByPesel(string pesel);

        void AddPatient(Patient patient);
    }
}