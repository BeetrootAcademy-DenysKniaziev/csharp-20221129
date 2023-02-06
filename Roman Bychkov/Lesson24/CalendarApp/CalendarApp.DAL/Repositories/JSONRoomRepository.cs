using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CalendarApp.DAL.Repositories
{
    internal class JSONRoomRepository : IRepository<Room>
    {
        private const string FileName = "Room.json";

        public IEnumerable<Room> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return Enumerable.Empty<Room>();
            }
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate);
            var rooms = JsonSerializer.Deserialize<IEnumerable<Room>>(fs);
            return rooms;
        }

        public void Add(Room room)
        {
            var rooms = GetAll();
            rooms = rooms.Append(room);
            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(fs, rooms);

        }
        public void Update(Room room)
        {
            var rooms = GetAll();

            var temp = rooms.Where(r => r.Id == room.Id).FirstOrDefault();
            temp.Schedule = room.Schedule;


            using var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(fs, rooms);

        }
    }
}
