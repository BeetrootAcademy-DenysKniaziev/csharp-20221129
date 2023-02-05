using Calendar.DAL.Repositorys.Interface;
using Calendar.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Calendar.DAL.Repositorys
{
    internal class MeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.json";
        //private readonly List<Meeting> _meetings = new List<Meeting>
        //{
        //    new Meeting("Test Meeting", DateTime.UtcNow, DateTime.UtcNow.AddHours(8), "Green")
        //};
        public void Add(Meeting meeting) //=> _meetings.Add(meeting);
        {
            var meetings = GetAll();
            meetings = meetings.Append(meeting);
            var json = JsonConvert.SerializeObject(meetings, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }
        public IEnumerable<Meeting> GetAll() //=> _meetings;
        {
            if (!File.Exists(FileName))
                return Enumerable.Empty<Meeting>();
            var json = File.ReadAllText(FileName);
            //var meeting = JsonConvert.DeserializeObject<IEnumerable<Meeting>>(json)  == null ? Enumerable.Empty<Meeting>() : JsonConvert.DeserializeObject<IEnumerable<Meeting>>(json);
            var meetings = JsonConvert.DeserializeObject<IEnumerable<Meeting>>(json) ?? Enumerable.Empty<Meeting>();
            return meetings;
        }
    }
}
