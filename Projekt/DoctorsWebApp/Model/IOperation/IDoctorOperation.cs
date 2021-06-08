namespace Model.IOperation
{
    public interface IDoctorOperation
    {
        void LoadDoctorList();

        void LoadMatchList();

        void LoadSexMatchList();

        void DeleteDoctorById();

        void DeleteDoctorByPesel();

        void AddDoctor();

        void AddSpecializationToNewDoctor();
    }
}