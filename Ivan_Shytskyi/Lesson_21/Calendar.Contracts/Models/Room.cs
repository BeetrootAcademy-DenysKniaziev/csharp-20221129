namespace Calendar.Contracts.Models
{
    public class Room
    {
        public string RoomName { get; set; }
        public Room(string RoomName)
        {
            this.RoomName = RoomName;
        }
    }
}
