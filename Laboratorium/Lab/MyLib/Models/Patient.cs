namespace MyLib.Models
{
    public class Patient : Person
    {
        public Patient(int id, string name) : base(id, name)
        {
        }

        public override bool CanOperate()
        {
            return false;
        }
    }
}