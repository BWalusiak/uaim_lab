namespace Controller
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Model.Models;

    public interface IController : INotifyPropertyChanged
    {

        Task GetAllDoctors();

        Task GetAllPatients();

        Task GetMatches();

        Task GetMatchesSex();

        Task AddPatient();

        Task AddDoctor();

        Task DeletePatientId();

        Task DeleteDoctorId();

        Task DeletePatientPesel();

        Task DeleteDoctorPesel();

        Task AddConditionToNewConditionList();

        Task AddSpecializationToNewSpecializationList();
    }
}