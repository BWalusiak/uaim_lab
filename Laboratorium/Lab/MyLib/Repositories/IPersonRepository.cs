namespace MyLib.Repositories
{
    using Models;

    public interface IPersonRepository
    {
        Person[] Find(Sex sex);
    }
}