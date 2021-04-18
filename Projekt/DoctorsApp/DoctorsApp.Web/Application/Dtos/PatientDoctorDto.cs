namespace DoctorsApp.Web.Application.Dtos
{
    public class PatientDoctorDto
    {
        public DoctorDto Doctor { get; set; }
        
        public PatientDto Patient { get; set; }
        
        public PatientDoctorDto(DoctorDto doctor, PatientDto patient)
        {
            Doctor = doctor;
            Patient = patient;
        }
    }
}