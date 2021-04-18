namespace DoctorsApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface ISelectorQueryHandler
    {
        public Task<IEnumerable<PatientDto>> GetPatientsThatDoctorCanTreat(int id);

        public Task<IEnumerable<PatientDoctorDto>> GetBestPatientDoctorMatches();
    }
}