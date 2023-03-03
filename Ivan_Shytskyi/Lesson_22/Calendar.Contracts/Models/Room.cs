using System;

namespace Calendar.Contracts.Models
{
    public class Room : BaseEntity<Guid>
    {
        public string RoomName { get; set; }
        public Room(string RoomName) : base(Guid.NewGuid())
        {
            this.RoomName = RoomName;
        }
    }
}
