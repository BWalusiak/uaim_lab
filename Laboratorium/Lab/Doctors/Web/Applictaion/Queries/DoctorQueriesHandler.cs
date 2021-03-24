namespace Doctors.Web.Applictaion.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Dtos;
    using Infrastructure.Repositories;
    using Mapper;

    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorQueriesHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return _doctorRepository.GetAll().Select(r => r.Map());
        }

        public IEnumerable<DoctorDto> GetBySpecialization(int specialization)
        {
            return _doctorRepository.GetBySpecialization(specialization)?.Select(ld => ld.Map());
        }
    }

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}