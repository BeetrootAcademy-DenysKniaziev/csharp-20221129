using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using System.Collections.Generic;

namespace Calendar.DAL.Repositorys
{
    internal class RoomsRepository : IRepository<Room>
    {
        protected readonly List<Room> _rooms = new List<Room>();
        public void Add(Room room) => _rooms.Add(room);
        public IEnumerable<Room> GetAll() => _rooms;
    }
}
