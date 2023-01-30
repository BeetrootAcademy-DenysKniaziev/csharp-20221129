using CalendarApp.DAL.Repositories.Interfaces;
using CalendarApp.Contracts.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace CalendarApp.DAL.Repositories
{
    internal class JsonMeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.json";

        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
                return Enumerable.Empty<Meeting>();
;
            var json = File.ReadAllText(FileName);
            var meetings = JsonConvert.DeserializeObject<IEnumerable<Meeting>>(json) ?? Enumerable.Empty<Meeting>();
            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();
            meetings = meetings.Append(meeting);
            var json = JsonConvert.SerializeObject(meetings, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }
    }
}
