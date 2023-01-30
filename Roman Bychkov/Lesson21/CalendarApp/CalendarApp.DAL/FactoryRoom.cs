using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories;
using CalendarApp.DAL.Repositories.Interfaces;

namespace CalendarApp.DAL
{
    public static class FactoryRoom
    {
        public static IRepository<Room> RoomsRepository { get; } = new JSONRoomRepository();
    }
}
