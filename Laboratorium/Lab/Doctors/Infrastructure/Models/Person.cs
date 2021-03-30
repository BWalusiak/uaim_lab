namespace Doctors.Infrastructure.Models
{
    using System.Diagnostics;

    public abstract class Person
    {
        #region Constructors

        protected Person()
        {
        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        #region Properties and Fields

        public int Id { get; set; }

        public Sex Sex { get; set; }

        public string Name { get; set; }

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