using System;

namespace CalendarApp.Contracts.Models
{
    public class Meeting
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Room Room { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Meeting meeting)
                return meeting.Id == Id;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
