namespace MyLib
{
    public class Doctor : Person
    {
        public Doctor(string name, bool isSurgeon) : base(name)
        {
            IsSurgeon = isSurgeon;
        }

        public bool IsSurgeon { get; set; }

        public override bool CanOperate()
        {
            return IsSurgeon;
        }

        public override string GetDescription()
        {
            return $"Dr {Name} of sex {Sex}";
        }
    }
}