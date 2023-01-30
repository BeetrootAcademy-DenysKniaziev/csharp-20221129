using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace CalendarApp.BLL.Services
{
    internal class RoomService : IService<Room>
    {
        private readonly IRepository<Room> _rooms;

        public RoomService(IRepository<Room> rooms)
        {
            _rooms = rooms;
        }

        public IEnumerable<Room> GetAll() => _rooms.GetAll();

        public void Add(Room room) => _rooms.Add(room);

        public void Update(Room entity) => _rooms.Update(entity);
    }
}
