using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CalendarApp.DAL.Repositories
{
    internal class RoomsRepository : IRepository<Room>
    {
        private List<Room> _rooms = new List<Room>
        {
            new Room
            {
                Name = "Not selected",
                IsProjector = false,
                Capacity = 0
            },
            new Room
            {
                Name = "Jupiter",
                IsProjector = true,
                Capacity = 15
            }
        };

        public IEnumerable<Room> GetAll()
        {

            if (File.Exists("rooms.json"))
                return _rooms = JsonConvert.DeserializeObject<IEnumerable<Room>>(File.ReadAllText("rooms.json")).ToList();

            return _rooms;
        }

        public void Add(Room room) 
        {
            _rooms.Add(room);
            File.WriteAllText("rooms.json", JsonConvert.SerializeObject(_rooms, Formatting.Indented));
        }

    }
}
