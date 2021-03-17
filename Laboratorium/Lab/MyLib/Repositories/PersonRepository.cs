using System.Collections.Generic;
using System.Linq;
using MyLib.Models;

namespace MyLib.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] _persons =
        {
            new Patient(3, "Jan kowalski") {Sex = Sex.Male},
            new Patient(4, "Anna Smith") {Sex = Sex.Female},
            new Doctor(1, "Stefan Nowak", true, new List<int> {10, 34, 87}) {Sex = Sex.Male},
            new Doctor(2, "Marianna Kowalska", false, new List<int> {23, 98, 56}) {Sex = Sex.Female}
        };

        public Person[] Find(Sex sex)
        {
            IList<Person> foundPersons = _persons.Where(s => s.Sex == sex).ToList();

            return foundPersons.ToArray();
        }
    }
}