using System.Diagnostics;

namespace MyLib.Models
{
    public abstract class Person
    {
        #region Constructors

        public Person(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties and Fields

        public Sex Sex { get; set; }

        public string Name
        {
            get => _name;

            internal set
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(value));

                _name = value;
            }
        }

        private string _name;

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return $"{Name} of sex {Sex}";
        }

        public abstract bool CanOperate();

        #endregion
    }
}