using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] _persons =
        {
            new Doctor("Stefan Nowak", true) {Sex = Sex.Male},
            new Doctor("Marianna Kowalska", false) {Sex = Sex.Female}
        };

        public Person[] Find(Sex color)
        {
            IList<Person> foundPersons = _persons.Where(s => s.Sex == color).ToList();

            return foundPersons.ToArray();
        }
    }
}