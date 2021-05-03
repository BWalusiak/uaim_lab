namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    public class MatchDto
    {
        public MatchDto(DoctorDto doctor, ExaminationRoomDto examinationRoom)
        {
            Doctor = doctor;
            ExaminationRoom = examinationRoom;
        }

        public DoctorDto Doctor { get; set; }
        public ExaminationRoomDto ExaminationRoom { get; set; }
    }
}