namespace CalendarApp.Contracts.Models
{
    public class Room
    {
        private static int ID = 0;

        public Room()
        {
            Id = ID;
            ID++;
        }
        public int Id { get; }

        public int Capacity { get; set; }
        public bool IsFree { get; set; } = true;

    }
}
