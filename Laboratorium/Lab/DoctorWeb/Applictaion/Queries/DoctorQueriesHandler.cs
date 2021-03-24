using System.Collections.Generic;
using System.Linq;
using DoctorWeb.Applictaion.Dtos;
using DoctorWeb.Applictaion.Mapper;
using MyLib.Repositories;

namespace DoctorWeb.Applictaion.Queries
{
    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorQueriesHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return _doctorRepository.GetAll().Select(r=>r.Map());
        }

        public IEnumerable<DoctorDto> GetBySpecialization(int specialization)
        {
            return _doctorRepository.GetBySpecialization(specialization)?.Select(ld=>ld.Map());
        }
    }
}