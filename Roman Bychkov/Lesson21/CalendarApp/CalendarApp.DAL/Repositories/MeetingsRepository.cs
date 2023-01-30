using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace CalendarApp.DAL.Repositories
{
    internal class MeetingsRepository : IRepository<Meeting>
    {
        private readonly List<Meeting> _meetings = new List<Meeting>
        //TODO: Remove
        {
            new Meeting
            {
                Name = "Test Meeting",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(1),
            }
        };

        public IEnumerable<Meeting> GetAll() => _meetings;

        public void Add(Meeting meeting) => _meetings.Add(meeting);
    }
}
