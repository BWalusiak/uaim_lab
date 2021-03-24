namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System;
    using SeedWork;

    public class Certification : Entity
    {
        public DateTime GrantedAt { get; }
        public int Type {get; }

        public Certification(int id, DateTime grantedAt, int type) : base(id)
        {
            GrantedAt = grantedAt;
            Type = type;
        }
    }
}
