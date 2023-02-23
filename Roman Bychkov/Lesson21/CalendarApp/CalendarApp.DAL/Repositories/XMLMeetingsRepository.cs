using System.Linq;
using System.Xml.Serialization;

namespace CalendarApp.DAL.Repositories
{
    internal class XMLMeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.xml";
        private static readonly XmlSerializer xmlSerializer = new(typeof(Meeting[]));
        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Meeting>();
            }
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate);
            var meetings = xmlSerializer.Deserialize(fs) as IEnumerable<Meeting> ?? Enumerable.Empty<Meeting>();

            //to synchronise with the rooms after start-up
            foreach (var meeting in meetings)
                meeting.Room = FactoryXML.RoomsRepository.GetAll().FirstOrDefault(r => r.Equals(meeting.Room));

            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();

            meetings = meetings.Append(meeting);
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fs, meetings.ToArray());
        }

        public void Update(Meeting meeting)
        {
            var meetings = GetAll();

            var temp = meetings.FirstOrDefault(m => m.Id == meeting.Id);
            if (temp == null)
                return;
            temp.Name = meeting.Name;
            temp.Room = meeting.Room;
            temp.StartTime = meeting.StartTime;
            temp.EndTime = meeting.EndTime;


            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fs, meetings.ToArray());
        }
    }
}
