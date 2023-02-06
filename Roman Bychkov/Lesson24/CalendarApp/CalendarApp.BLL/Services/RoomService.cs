using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Add(Room room)
        {
            if (room.Capacity < 1)
                throw new ArgumentException("Invalid capacity");
            if (_rooms.GetAll().Count() != 0 && room.Id <= _rooms.GetAll().Max(r => r.Id))
                throw new ArgumentException("Invalid ID");
            _rooms.Add(room);
        }

        public void Update(Room entity) => _rooms.Update(entity);
    }

    public static class ExtensionRoomService
    {
        public static IEnumerable<Room> GetFreeRooms(this IService<Room> roomsservice, DateTime start, DateTime end)
        {
            return (from r in roomsservice.GetAll()
                    from s in r.Schedule
                    where (start < s.Start || s.End < start) && r.Schedule.All(x => x.Start > end || x.End < start)
                    select r).Distinct().Union(roomsservice.GetAll().Where(r => r.Schedule.Count == 0));
        }
    }
}
