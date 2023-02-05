using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Calendar.DAL.Repositorys
{
    internal class RoomsRepository : IRepository<Room>
    {
        private const string FileName = "Rooms.json";
        public void Add(Room room)
        {
            var rooms = GetAll();
            rooms = rooms.Append(room);
            var json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }
        public IEnumerable<Room> GetAll()
        {
            if (!File.Exists(FileName))
                return Enumerable.Empty<Room>();
            var json = File.ReadAllText(FileName);
            var rooms = JsonConvert.DeserializeObject<IEnumerable<Room>>(json) ?? Enumerable.Empty<Room>();
            return rooms;
        }
    }
}
