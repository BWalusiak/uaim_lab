namespace Uaim1
{
    public interface IShapeRepository
    {
        Shape[] Find(ShapeColor color);
    }
}