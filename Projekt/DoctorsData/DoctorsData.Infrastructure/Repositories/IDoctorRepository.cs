namespace DoctorsData.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using Domain.Models;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetByType(int type);
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int Id);
        Doctor GetByPesel(string Pesel);

        void AddDoctor(Doctor doctor);
    }
}