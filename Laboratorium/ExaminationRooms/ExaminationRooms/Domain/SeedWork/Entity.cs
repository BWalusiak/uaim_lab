namespace ExaminationRooms.Domain.SeedWork
{
    public abstract class Entity
    {
        protected Entity()
        {
        }

        public int Id { get; set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
