namespace Doctors.Infrastructure.Models
{
    public abstract class Entity
    {
        public Entity(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }
    }
}