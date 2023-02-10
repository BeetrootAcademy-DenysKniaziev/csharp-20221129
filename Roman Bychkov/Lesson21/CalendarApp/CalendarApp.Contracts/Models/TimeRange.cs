using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Contracts.Models
{
    public struct TimeRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}
