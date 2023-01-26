using System;

namespace CalendarApp.Contracts.Models
{
    public class Meeting
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string RoomName { get; set; }
    }
}
