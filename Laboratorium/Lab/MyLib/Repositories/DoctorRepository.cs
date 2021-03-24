namespace MyLib.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class DoctorRepository : IDoctorRepository
    {
        private readonly Doctor[] _doctors =
        {
            new(1, "Stefan Nowak", true, new List<int> {1, 5, 6}) {Sex = Sex.Male},
            new(2, "Marianna Kowalska", false, new List<int> {7, 6, 9}) {Sex = Sex.Female}
        };

        public IEnumerable<Doctor> GetBySpecialization(int specializtion)
        {
            return _doctors.Where(d => d.Specializations.Any(s => s == specializtion));
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctors;
        }
    }
}