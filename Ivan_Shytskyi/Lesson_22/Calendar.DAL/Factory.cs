using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using Calendar.DAL.Repositorys;

namespace Calendar.DAL
{
    public static class Factory
    {
        public static IRepository<Meeting> MeetingsRepository { get; } = new JSONMeetingsRepository();
        //public static IRepository<Meeting> MeetingsRepository { get; } = new XMLMeetingsRepository();

        public static IRepository<Room> RoomsRepository { get; } = new JSONRoomsRepository();
        //public static IRepository<Room> RoomsRepository { get; } = new XMLRoomsRepository();
    }

}
