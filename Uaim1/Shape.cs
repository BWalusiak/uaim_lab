using System;
using System.Diagnostics;

namespace Uaim1
{
    public abstract class Shape
    {
        #region Properties and Fields

        public ShapeColor Color { get; set; }

        public string Name
        {
            get { return this.name; }

            internal set
            {
                Debug.Assert(condition: !String.IsNullOrWhiteSpace(value));

                this.name = value;
            }
        }

        private string name;

        #endregion

        #region Constructors

        public Shape(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return $"{this.Name} of color {this.Color}";
        }

        public abstract double GetArea();

        #endregion
    }
}