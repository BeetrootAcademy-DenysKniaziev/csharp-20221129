using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarApp.BLL.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRepository<Room> _rooms;

        public RoomService(IRepository<Room> rooms)
        {
            _rooms = rooms;
        }

        public IEnumerable<Room> GetAll() => _rooms.GetAll();

        public void Add(Room room)
        {
            if (room.Capacity < 1)
                throw new ArgumentException("Invalid capacity");
            _rooms.Add(room);
        }

        public void Update(Room entity) => _rooms.Update(entity);

        public IEnumerable<Room> GetFreeRooms(DateTime start, DateTime end)
        {
            return (from r in GetAll()
                    from s in r.Schedule
                    where (start < s.Start || s.End < start) && r.Schedule.All(x => x.Start > end || x.End < start)
                    select r).Distinct().Union(GetAll().Where(r => r.Schedule.Count == 0));
        }
    }
}
