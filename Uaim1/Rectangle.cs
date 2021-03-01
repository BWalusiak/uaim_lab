using System.Diagnostics;

namespace Uaim1
{
    public class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Debug.Assert(condition: width > 0 && height > 0);

            this.Width = width;
            this.Height = height;
        }

        public override double GetArea()
        {
            return this.Width * this.Height;
        }
    }
}