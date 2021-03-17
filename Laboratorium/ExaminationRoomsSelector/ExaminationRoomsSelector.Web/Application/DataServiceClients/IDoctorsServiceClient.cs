using System.Collections.Generic;
using System.Threading.Tasks;
using ExaminationRoomsSelector.Web.Application.Dtos;

namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    public interface IDoctorsServiceClient
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
    }
}