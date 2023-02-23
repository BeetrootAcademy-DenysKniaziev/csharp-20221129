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

            //to synchronise with the rooms after start-up
            foreach (var meeting in meetings)
                meeting.Room = FactoryJSON.RoomsRepository.GetAll().FirstOrDefault(r => r.Equals(meeting.Room));

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
            if (temp == null)
                return;

            temp.Name = meeting.Name;
            temp.Room = meeting.Room;
            temp.StartTime = meeting.StartTime;
            temp.EndTime = meeting.EndTime;
           
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(fs, meetings);
        }
    }
}
