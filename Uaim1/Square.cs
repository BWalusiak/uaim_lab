using System.Diagnostics;

namespace Uaim1
{
    public class Square : Shape
    {
        public double Size { get; private set; }

        public Square(string name, double size) : base(name)
        {
            Debug.Assert(condition: size > 0);

            this.Size = size;
        }

        public override double GetArea()
        {
            return this.Size * this.Size;
        }
    }
}