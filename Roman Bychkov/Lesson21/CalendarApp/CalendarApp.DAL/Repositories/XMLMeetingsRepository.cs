using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CalendarApp.DAL.Repositories
{
    internal class XMLMeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.xml";

        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Meeting>();
            }
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate);
            var meetings = XmlSerializer.Deserialize(fs) as Enumerable<Meeting>;

            //to synchronise with the rooms after start-up
            foreach (var meeting in meetings)
                meeting.Room = Factory.RoomsRepository.GetAll().FirstOrDefault(r => r.Equals(meeting.Room));

            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();

            meetings = meetings.Append(meeting);
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(fs, meetings);

        }

        public void Update(Meeting meeting)
        {
            var meetings = GetAll();

            var temp = meetings.FirstOrDefault(m => m.Id == meeting.Id);

            temp.Name = meeting.Name;
            temp.Room = meeting.Room;
            temp.StartTime = meeting.StartTime;
            temp.EndTime = meeting.EndTime;


            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(fs, meetings);
        }
    }
}
