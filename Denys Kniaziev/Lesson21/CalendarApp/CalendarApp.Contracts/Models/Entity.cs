namespace CalendarApp.Contracts.Models
{
    public class Entity<TKey>
    {
        public TKey Id { get; set; }

         public Entity(TKey id)
        {
            Id = id;
        }
    }
}
