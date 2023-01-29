using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace CalendarApp.DAL.Repositories
{
    internal class RoomRepository : IRepository<Room>
    {
        private readonly List<Room> _meetings = new List<Room>
        //TODO: Remove
        {
            new Room
            {
                Id = 1,
                Capacity = 15
            }
        };

        public IEnumerable<Room> GetAll() => _meetings;

        public void Add(Room meeting) => _meetings.Add(meeting);
    }
}
