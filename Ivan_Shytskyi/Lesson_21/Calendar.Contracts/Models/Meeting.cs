using System;

namespace Calendar.Contracts.Models
{
    public class Meeting
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
        public Meeting(string Name, DateTime StartTime, DateTime EndTime, string Room)
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Room = Room;
        }
    }
}
