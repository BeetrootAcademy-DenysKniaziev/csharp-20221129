using System;
using System.Collections.Generic;


namespace CalendarApp.Contracts.Models
{
    public class Room
    {
        private static int ID = 0;
        public int Id { get; }

        public int Capacity { get; set; }
        public List<TimeRange> Schedule { get; set; }
        public Room(int capacity, List<TimeRange> schedule = null, int id = -1)
        {
            if (id == -1)
            {
                this.Id = ID;
                Schedule = new List<TimeRange>();
                ID++;
            }
            else
            {
                this.Id = id;
                Schedule = schedule;
                ID = id + 1;
            }

            Capacity = capacity;


        }
       
        public override bool Equals(object obj)
        {
            if (obj is Room room)
                return room.Id == this.Id;
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
