namespace MyLib.Models
{
    using System.Collections.Generic;

    public class Doctor : Person
    {
        public Doctor(int id, string name, bool isSurgeon, List<int> specializations) : base(id, name)
        {
            IsSurgeon = isSurgeon;
            Specializations = specializations;
        }

        public bool IsSurgeon { get; }

        public IList<int> Specializations { get; }

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