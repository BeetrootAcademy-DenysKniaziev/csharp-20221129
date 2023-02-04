using System;
using Calendar.DAL.Repositorys.Interface;
using Calendar.Contracts.Models;
using System.Collections.Generic;

namespace Calendar.DAL.Repositorys
{
    internal class MeetingsRepository : IRepository<Meeting>
    {
        private readonly List<Meeting> _meetings = new List<Meeting>
        {
            new Meeting("Test Meeting", DateTime.UtcNow, DateTime.UtcNow.AddHours(8), "Green")
        };
        public void Add(Meeting meeting) => _meetings.Add(meeting);
        public IEnumerable<Meeting> GetAll() => _meetings;
    }
}
