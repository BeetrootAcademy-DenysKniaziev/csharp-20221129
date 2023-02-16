using Newtonsoft.Json;
using System;

namespace CalendarApp.Contracts.Models
{
    public class Meeting : Entity<Guid>
    {
        public Meeting(string name) : this(Guid.NewGuid(), name)
        {
        }

        [JsonConstructor]
        public Meeting(Guid id, string name) : base(id)
        {
            Name = name;
            //...
        }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string RoomName { get; set; }

        public DateTime? Created { get; set; }

        //public Room Room { get; set; }

        public Guid RoomId { get; set; }
    }
}
