using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] _persons =
        {
            new Patient("Jan kowalski") {Sex = Sex.Male},
            new Patient("Anna Smith") {Sex = Sex.Female},
            new Doctor("Stefan Nowak", true,new List<int> {10, 34, 87}) {Sex = Sex.Male},
            new Doctor("Marianna Kowalska", false, new List<int>{23, 98, 56}) {Sex = Sex.Female}
        };

        public Person[] Find(Sex sex)
        {
            IList<Person> foundPersons = _persons.Where(s => s.Sex == sex).ToList();

            return foundPersons.ToArray();
        }
    }
}