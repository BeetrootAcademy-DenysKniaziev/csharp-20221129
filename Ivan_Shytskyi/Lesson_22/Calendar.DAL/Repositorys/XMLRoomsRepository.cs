using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Calendar.DAL.Repositorys
{
    internal class XMLRoomsRepository : IRepository<Room>
    {
        private const string FileName = "Rooms.xml";

        public void Add(Room room)
        {
            var rooms = GetAll();
            rooms = rooms.Append(room);

            var serializer = new XmlSerializer(typeof(Room));
            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.Serialize(fs, rooms);
            }

        }
        public IEnumerable<Room> GetAll()
        {
            if (!File.Exists(FileName))
                return Enumerable.Empty<Room>();
            var serializer = new XmlSerializer(typeof(Room));
            IEnumerable<Room> rooms;
            using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                rooms = serializer.Deserialize(fs) as IEnumerable<Room> ?? Enumerable.Empty<Room>();
            }
            return rooms;
        }
    }
}
