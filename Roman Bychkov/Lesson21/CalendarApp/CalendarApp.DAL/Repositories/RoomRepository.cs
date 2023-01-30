using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace CalendarApp.DAL.Repositories
{
    internal class RoomRepository : IRepository<Room>
    {
        private readonly List<Room> _rooms = new List<Room>();
       
        public IEnumerable<Room> GetAll() => _rooms;

        public void Add(Room room) => _rooms.Add(room);
    }
}
