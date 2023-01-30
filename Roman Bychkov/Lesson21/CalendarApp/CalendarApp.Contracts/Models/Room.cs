using System;
using System.Collections.Generic;

namespace CalendarApp.Contracts.Models
{
    public class Room
    {
        private static int ID = 0;

        //public Room()
        //{
        //    Id = ID;
        //    ID++;
        //    Schedule = new Dictionary<DateTime, DateTime>();

        //}
        public Room(int capacity, Dictionary<DateTime, DateTime> schedule = null, int id = -1)
        {
            if (id == -1)
            {
                this.Id = ID;
                ID++;
                Schedule = new Dictionary<DateTime, DateTime>();
                
            }
            else
            {
                this.Id = id;
                Schedule = schedule;
            }

            Capacity = capacity;


        }
        public int Id { get; }

        public int Capacity { get; set; }
        public Dictionary<DateTime, DateTime> Schedule { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Room room)
                return room.Id == this.Id;
            return false;
        }

    }
}
