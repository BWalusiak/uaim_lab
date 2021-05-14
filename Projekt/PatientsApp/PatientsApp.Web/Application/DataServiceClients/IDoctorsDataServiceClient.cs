namespace PatientsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastrucutre.Models;

    public interface IDoctorsDataServiceClient
    {
        public Task<IEnumerable<Doctor>> GetDoctorsBySpecializationId(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctors();
    }
}