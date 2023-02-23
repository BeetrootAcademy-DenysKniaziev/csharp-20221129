using CsvHelper;
using System.Globalization;

namespace CalendarApp.DAL.Repositories.Interfaces
{
    internal class CSVRoomRepository : IRepository<Room>
    {
        private const string FileName = "Room.csv";

        public IEnumerable<Room> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Room>();
            }
            using var reader = new StreamReader(FileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var rooms = csv.GetRecords<Room>().ToList();

            return rooms;
        }

        public void Add(Room room)
        {
            var rooms = GetAll();
            rooms = rooms.Append(room);
            
            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords<Room>(rooms);
           

        }
        public void Update(Room room)
        {
            var rooms = GetAll();

            var temp = rooms.FirstOrDefault(r => r.Id == room.Id);
            if (temp == null)
                return;
            temp.Schedule = room.Schedule;
            temp.Capacity = room.Capacity;
           


            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords<Room>(rooms);

        }
    }
}
