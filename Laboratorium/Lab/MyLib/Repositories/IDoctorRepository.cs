using System.Collections.Generic;
using MyLib.Models;

namespace MyLib.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetBySpecialization(int specializtion);
        IEnumerable<Doctor> GetAll();
    }
}