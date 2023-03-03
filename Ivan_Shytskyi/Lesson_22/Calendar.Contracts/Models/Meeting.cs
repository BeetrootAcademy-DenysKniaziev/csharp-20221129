using System;

namespace Calendar.Contracts.Models
{
    public class Meeting : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public Meeting(string Name, DateTime StartTime, DateTime EndTime, string id, string Room) : base (Guid.NewGuid())
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            RoomName = Room;
            RoomId = id;
        }
    }
}
