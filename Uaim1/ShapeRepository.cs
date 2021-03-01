using System.Collections.Generic;
using System.Linq;

namespace Uaim1
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly Shape[] shapes =
        {
            new Square("kwadrat1", 1.0) {Color = ShapeColor.Green},
            new Rectangle("prostokat1", 2.0, 1.0) {Color = ShapeColor.Red},
            new Rectangle("prostokat2", 1.0, 2.0) {Color = ShapeColor.Green}
        };

        public Shape[] Find(ShapeColor color)
        {
            IList<Shape> foundShapes = shapes.Where(s => s.Color == color).ToList();

            return foundShapes.ToArray();
        }
    }
}