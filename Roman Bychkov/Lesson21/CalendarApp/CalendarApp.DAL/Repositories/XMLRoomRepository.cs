using System.Xml.Serialization;

namespace CalendarApp.DAL.Repositories
{
    internal class XMLRoomRepository : IRepository<Room>
    {
        private const string FileName = "Room.xml";
        private static readonly XmlSerializer xmlSerializer = new(typeof(Room[]));


        public IEnumerable<Room> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Room>();
            }
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate);
            var rooms = xmlSerializer.Deserialize(fs) as IEnumerable<Room> ?? Enumerable.Empty<Room>();
            return rooms;
        }

        public void Add(Room room)
        {
            var rooms = GetAll();
            rooms = rooms.Append(room);
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fs, rooms.ToArray());

        }
        public void Update(Room room)
        {
            var rooms = GetAll();

            var temp = rooms.FirstOrDefault(r => r.Id == room.Id);

            temp.Schedule = room.Schedule;
            temp.Capacity = room.Capacity;


            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            xmlSerializer.Serialize(fs, rooms.ToArray());

        }
    }
}
