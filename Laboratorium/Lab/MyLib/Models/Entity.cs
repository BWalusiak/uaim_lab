namespace MyLib.Models
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public Entity(int id) 
        {
            Id = id;
        }
    }
}