namespace MyLib
{
    public class Patient : Person
    {
        public Patient(string name) : base(name)
        {
        }

        public override bool CanOperate()
        {
            return false;
        }
    }
}