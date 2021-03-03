namespace MyLib
{
    public interface IPersonRepository
    {
        Person[] Find(Sex sex);
    }
}