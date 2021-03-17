using MyLib.Models;

namespace MyLib.Repositories
{
    public interface IPersonRepository
    {
        Person[] Find(Sex sex);
    }
}