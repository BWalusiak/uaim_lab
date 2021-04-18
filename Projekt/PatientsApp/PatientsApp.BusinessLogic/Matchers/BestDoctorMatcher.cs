namespace PatientsApp.BusinessLogic.Matchers
{
    using System.Collections.Generic;
    using System.Linq;
    using DoctorsData.Infrastructure.Models;
    using Infrastrucutre.Models;
    using PatientsData.Infrastructure.Models;

    public class BestDoctorMatcher : IBestDoctorMatcher
    {
        private readonly IEnumerable<Doctor> _doctors;
        private readonly Patient _patient;

        public BestDoctorMatcher(Patient patient, IEnumerable<Doctor> doctors)
        {
            _patient = patient;
            _doctors = doctors;
        }

        public Doctor GetBestDoctor()
        {
            var doctorsList = _doctors.ToList();
            doctorsList.Sort((d1, d2) => d2.Specializations.Count() - d1.Specializations.Count());
            var bestDoctor = doctorsList.First();
            var maxTreatments = 0;
            foreach (var doctor in doctorsList)
            {
                if (maxTreatments >= doctor.Specializations.Count())
                    break;

                var treatmentCount = _patient.Conditions.Select(dto => dto.Type)
                    .Intersect(doctor.Specializations.Select(dto => dto.Type)).Count();

                if (treatmentCount <= maxTreatments)
                    continue;
                bestDoctor = doctor;
                maxTreatments = treatmentCount;
            }

            return bestDoctor;
        }
    }

    internal interface IBestDoctorMatcher
    {
        public Doctor GetBestDoctor();
    }
}