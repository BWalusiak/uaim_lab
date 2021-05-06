namespace PatientsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastrucutre.Models;
    using PatientsData.Infrastructure.Models;

    public interface IPatientsQueryHandler
    {
        void AddPatient(Patient patient);
        void DeletePatient(int id);
        void DeletePatient(string pesel);

        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<IEnumerable<Patient>> GetAllPatientsByConditionIdAsync(int type);
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> GetByPeselAsync(string pesel);

        Doctor GetBestDoctorByPatientId(int id);
    }
}