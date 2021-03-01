using System;
using System.Diagnostics;

namespace Uaim1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IShapeRepository shapeRepository = new ShapeRepository();

            Debug.Assert(shapeRepository != null);

            foreach (var shape in shapeRepository.Find(ShapeColor.Green))
            {
                var shapeDescription = shape.GetDescription();
                var shapeArea = shape.GetArea();

                Console.WriteLine($"shape description = {shapeDescription}; shape area = {shapeArea}");
            }

            Console.ReadLine();
        }
    }
}