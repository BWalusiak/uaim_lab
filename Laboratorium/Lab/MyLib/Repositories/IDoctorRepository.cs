namespace MyLib.Repositories
{
    using System.Collections.Generic;
    using Models;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetBySpecialization(int specializtion);
        IEnumerable<Doctor> GetAll();
    }
}