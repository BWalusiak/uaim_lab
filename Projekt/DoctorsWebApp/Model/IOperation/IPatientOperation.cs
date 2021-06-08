namespace Model.IOperation
{
    public interface IPatientOperation
    {
        void AddPatient();

        void AddConditionToNewPatient();

        void DeletePatientById();

        void DeletePatientByPesel();

        void LoadPatientList();
    }
}