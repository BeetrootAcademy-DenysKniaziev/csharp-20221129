using Newtonsoft.Json;
using System;

namespace CalendarApp.Contracts.Models
{
    public class Room : Entity<Guid>
    {
        public Room(string name) : this(Guid.NewGuid(), name)
        {
        }

        [JsonConstructor]
        public Room(Guid id, string name) : base(id)
        {
            Name = name;
            //...
        }
        public string Name { get; set; }

    }
}
