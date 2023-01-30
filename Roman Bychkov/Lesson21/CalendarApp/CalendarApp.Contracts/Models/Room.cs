using System;
using System.Collections.Generic;

namespace CalendarApp.Contracts.Models
{
    public class Room
    {
        private static int ID = 0;

        public Room()
        {
            Id = ID;
            ID++;
            Schedule = new Dictionary<DateTime, DateTime>();
            {
                Schedule.Add(DateTime.Now, DateTime.Now.AddHours(2));
            }
        }
        public int Id { get; }

        public int Capacity { get; set; }
        public Dictionary<DateTime, DateTime> Schedule { get; set; }

    }
}
