namespace PatientsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PatientsData.Infrastructure.Models;

    public interface IPatientsDataServiceClient
    {
        public Task<IEnumerable<Patient>> GetAllPatientsAsync();
        public Task<IEnumerable<Patient>> GetAllByConditionId(int type);

        public Task<Patient> GetPatientById(int id);
        public Task<Patient> GetPatientByPesel(string pesel);

        public void AddPatient(Patient patient);
        public void DeletePatient(int id);
        public void DeletePatient(string pesel);
    }
}