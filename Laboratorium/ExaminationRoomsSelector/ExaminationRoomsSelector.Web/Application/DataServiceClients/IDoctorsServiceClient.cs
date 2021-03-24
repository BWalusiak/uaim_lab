namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface IDoctorsServiceClient
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
    }
}