
using CalendarApp.Contracts.Models;
using System;
using System.Collections.Generic;

namespace CalendarApp.BLL.Services.Interfaces
{
    public interface IRoomService : IService<Room>
    {
        public IEnumerable<Room> GetFreeRooms(DateTime start, DateTime end);
    }
}
