using CalendarApp.BLL.Services;
using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;

using DALFactory = CalendarApp.DAL.FactoryRoom;

namespace CalendarApp.BLL
{
    public static class FactoryRoom
    {
        public static IService<Room> RoomService { get; } = new RoomService(DALFactory.RoomsRepository);
    }
}
