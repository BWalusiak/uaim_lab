namespace ExaminationRooms.Web.Application.Mapper
{
    using System.Linq;
    using Domain.ExaminationRoomAggregate;
    using Dtos;

    public static class Mapper
    {
        public static ExaminationRoomDto Map(this ExaminationRoom examinationRoom)
        {
            if (examinationRoom == null)
                return null;

            return new ExaminationRoomDto
            {
                Number = examinationRoom.Number,
                Certifications = examinationRoom?.Certifications.Select(s => s.Type)
            };
        }
    }
}
