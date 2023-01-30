using CalendarApp.DAL.Repositories.Interfaces;
using CalendarApp.Contracts.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CalendarApp.DAL.Repositories
{
    internal class XmlMeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.xml";
        private static readonly XmlSerializer Serializer = new(typeof(Meeting[]));

        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
                return Enumerable.Empty<Meeting>();

            using var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            var meetings = Serializer.Deserialize(fs) as IEnumerable<Meeting> ?? Enumerable.Empty<Meeting>();

            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();
            meetings = meetings.Append(meeting).ToArray();

            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            Serializer.Serialize(fs, meetings);
        }
    }
}
