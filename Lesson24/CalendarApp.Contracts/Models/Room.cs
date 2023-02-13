using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Contracts.Models
{
    public class Room
    {
        public string Name { get; set; }
        public bool IsProjector { get; set; }
        public int Capacity{ get; set; }
    }
}
