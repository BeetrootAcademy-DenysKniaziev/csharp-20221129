using Calendar.BLL.Services.Interface;
using Calendar.BLL.Services;
using Calendar.Contracts.Models;
using DALFactory = Calendar.DAL.Factory;
using static Calendar.BLL.Services.RoomsService;
//using DALRoomFactory = Calendar.DAL.RoomFactory;


namespace Calendar.BLL
{
    public static class Factory
    {
        public static IService<Meeting> meetingsService { get; } = new MeetingsService(DALFactory.MeetingsRepository);

        public static IService<Room> roomsService { get; } = new RoomsServise(DALFactory.RoomsRepository);
    }
}
