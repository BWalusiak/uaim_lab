using System.Collections.Generic;

namespace MyLib
{
    public class Doctor : Person
    {
        public Doctor(string name, bool isSurgeon, List<int> specializations) : base(name)
        {
            IsSurgeon = isSurgeon;
            Specializations = specializations;
        }

        public bool IsSurgeon { get; set; }

        public List<int> Specializations { get; }

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