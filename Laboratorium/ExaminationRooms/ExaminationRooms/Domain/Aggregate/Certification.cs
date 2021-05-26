namespace ExaminationRooms.Domain.Aggregate
{
    using System;
    using SeedWork;

    public class Certification : Entity
    {
        public Certification()
        {
        }

        public DateTime GrantedAt { get; set; }
        public int Type { get; set; }

        public Certification(int id, DateTime grantedAt, int type) : base(id)
        {
            GrantedAt = grantedAt;
            Type = type;
        }
    }
}
