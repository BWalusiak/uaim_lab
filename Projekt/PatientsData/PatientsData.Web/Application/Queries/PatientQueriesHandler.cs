namespace PatientsData.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Dtos;
    using Infrastructure.Repositories;
    using Mapper;

    public class PatientQueriesHandler : IPatientQueriesHandler
    {
        private readonly IPatientRepository patientRepository;

        public PatientQueriesHandler(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public IEnumerable<PatientDto> GetAll()
        {
            return patientRepository.GetAll().Select(s => s.Map());
        }

        public IEnumerable<PatientDto> GetByType(int type)
        {
            return patientRepository.GetByType(type)?.Select(s => s.Map());
        }

        public PatientDto GetById(int id)
        {
            return patientRepository.GetById(id)?.Map();
        }

        public PatientDto GetByPesel(string pesel)
        {
            return patientRepository.GetByPesel(pesel)?.Map();
        }

        public void AddPatient(PatientDto patientDto)
        {
            var patient = patientDto.UnMap();
            patientRepository.AddPatient(patient);
        }
    }
}