using System;
using System.Collections.Generic;
using System.Linq;
using MyLib.Models;

namespace MyLib.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly Doctor[] _doctors =
        {
            new(1, "Stefan Nowak", true, new List<int> {10, 34, 87}) {Sex = Sex.Male},
            new(2, "Marianna Kowalska", false, new List<int> {23, 98, 56}) {Sex = Sex.Female}
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