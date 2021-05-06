namespace DoctorsData.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using Domain.Models;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetByType(int type);
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        Doctor GetByPesel(string pesel);

        void AddDoctor(Doctor doctor);
        void DeleteDoctor(int id);
    }
}