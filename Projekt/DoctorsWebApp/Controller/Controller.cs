namespace Controller
{
    using System.Threading.Tasks;
    using Model.Models;
    using Utilities;

    public class Controller : PropertyContainerBase, IController
    {
        public Controller(IEventDispatcher dispatcher, IModel model) :
            base(dispatcher)
        {
            Model = model;
        }

        public IModel Model { get; }

        public async Task GetAllDoctors()
        {
            await Task.Run(() => Model.LoadDoctorList());
        }

        public async Task GetAllPatients()
        {
            await Task.Run(() => Model.LoadPatientList());
        }

        public async Task GetMatches()
        {
            await Task.Run(() => Model.LoadMatchList());
        }

        public async Task GetMatchesSex()
        {
            await Task.Run(() => Model.LoadSexMatchList());
        }

        public async Task AddPatient()
        {
            await Task.Run(() => Model.AddPatient());
        }

        public async Task AddDoctor()
        {
            await Task.Run(() => Model.AddDoctor());
        }

        public async Task DeletePatientId()
        {
            await Task.Run(() => Model.DeletePatientById());
        }

        public async Task DeleteDoctorId()
        {
            await Task.Run(() => Model.DeleteDoctorById());
        }

        public async Task DeletePatientPesel()
        {
            await Task.Run(() => Model.DeletePatientByPesel());
        }

        public async Task DeleteDoctorPesel()
        {
            await Task.Run(() => Model.DeleteDoctorByPesel());
        }

        public async Task AddConditionToNewConditionList()
        {
            await Task.Run(() => Model.AddConditionToNewPatient());
        }

        public async Task AddSpecializationToNewSpecializationList()
        {
            await Task.Run(() => Model.AddSpecializationToNewDoctor());
        }
    }
}