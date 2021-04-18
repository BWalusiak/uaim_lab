namespace DoctorsApp.Web.Logic.Selector
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Dtos;

    public static class PatientSelector
    {
        public static IEnumerable<PatientDto> GetPatientsThatDoctorCanTreat(DoctorDto doctorDto,
            IEnumerable<PatientDto> patientsDto)
        {
            return patientsDto.Where(patientDto => patientDto.Conditions.Any(x => 
                    doctorDto.Specializations.Any(y => y.Type == x.Type)));
        }

        public static IEnumerable<PatientDoctorDto> GetBestPatientDoctorMatches(IEnumerable<DoctorDto> doctorsDto,
            IEnumerable<PatientDto> patientsDto)
        {
            var doctors = doctorsDto.ToList();
            var patients = patientsDto.ToList();

            var list = new List<PatientDoctorDto>();

            foreach (var doctor in doctors)
            {
                var bestPatient = patients.First();
                var rank = GetRank(doctor, bestPatient);

                foreach (var room in patients)
                {
                    var x = GetRank(doctor, room);
                    if (x <= rank) continue;
                    rank = x;
                    bestPatient = room;
                }

                if (GetRank(doctor, bestPatient) == 0)
                    return list;

                list.Add(new PatientDoctorDto(doctor, bestPatient));
                patients.Remove(bestPatient);
            }

            return list;
        }

        private static int GetRank(DoctorDto doctorDto, PatientDto patientDto)
        {
            return doctorDto.Specializations.Sum(s => patientDto.Conditions.Count(c => s.Type == c.Type));
        }
    }
}