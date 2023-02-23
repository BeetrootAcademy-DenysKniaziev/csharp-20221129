﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CalendarApp.Contracts.Models
{
    public class Room
    {

        public Guid? Id { get; set; }

      
        public int Capacity { get; set; }
        public List<TimeRange> Schedule { get; set; }

        [JsonConstructor]
        public Room(int capacity, List<TimeRange> schedule = null, Guid? id = null)
        {
            if (id.HasValue)
            {
                this.Id = id.Value;
                Schedule = schedule;
            }
            else
            {
                this.Id = Guid.NewGuid();
                Schedule = new List<TimeRange>();
            }

            Capacity = capacity;
        }
        public Room()
        {
            Schedule = new List<TimeRange>();
        }

        public override bool Equals(object obj)
        {
            if (obj is Room room)
                return room.Id == Id;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}