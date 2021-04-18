namespace DoctorsData.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models;
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
            return _doctorRepository.GetAll().Select(doctor => doctor.Map());
        }

        public IEnumerable<DoctorDto> GetByType(int type)
        {
            return _doctorRepository.GetByType(type)?.Select(doctor => doctor.Map());
        }

        public DoctorDto GetById(int id)
        {
            return _doctorRepository.GetById(id)?.Map();
        }

        public DoctorDto GetByPesel(string pesel)
        {
            return _doctorRepository.GetByPesel(pesel)?.Map();
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            var doctor = doctorDto.UnMap();
            _doctorRepository.AddDoctor(doctor);
        }
    }
}