namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    public class MatchDto
    {
        public DoctorDto Doctor { get; set; }
        public ExaminationRoomDto ExaminationRoom { get; set; }

        public MatchDto(DoctorDto doctor, ExaminationRoomDto examinationRoom)
        {
            Doctor = doctor;
            ExaminationRoom = examinationRoom;
        }
    }
}