using Calendar.BLL.Services.Interface;
using Calendar.Contracts.Models;
using static Calendar.BLL.Services.RoomsService;
using DALRoomFactory = Calendar.DAL.RoomFactory;

namespace Calendar.BLL
{
    public static class RoomFactory
    {
        public static IService<Room> roomsService { get; } = new RoomsServise(DALRoomFactory.RoomsRepository);
    }
}
