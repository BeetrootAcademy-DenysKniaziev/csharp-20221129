using CalendarApp.DAL;
using CsvHelper;
using System.Globalization;

namespace CalendarApp.DAL.Repositories
{
    internal class CSVMeetingRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.csv";

        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Meeting>();
            }

            using var reader = new StreamReader(FileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var meetings = csv.GetRecords<Meeting>().ToList();

            //to synchronise with the rooms after start-up
            var rooms = FactoryCSV.RoomsRepository.GetAll();
            foreach (var meeting in meetings)
                meeting.Room = rooms.FirstOrDefault(r => r.Equals(meeting.Room));

            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();

            meetings = meetings.Append(meeting);

            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords<Meeting>(meetings);

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


            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords<Meeting>(meetings);
        }
    }
}
