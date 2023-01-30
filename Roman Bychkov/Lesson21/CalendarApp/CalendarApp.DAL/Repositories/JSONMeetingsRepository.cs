using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CalendarApp.DAL.Repositories
{
    internal class JSONMeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.json";

        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Meeting>();
            }
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate);
            var meetings = JsonSerializer.Deserialize<IEnumerable<Meeting>>(fs);
            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();

            meetings = meetings.Append(meeting);
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(fs,meetings);
           
        }

        public void Update(Meeting entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
