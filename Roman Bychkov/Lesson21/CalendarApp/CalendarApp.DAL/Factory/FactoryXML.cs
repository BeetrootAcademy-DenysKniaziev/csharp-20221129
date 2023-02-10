namespace CalendarApp.DAL
{
    public class FactoryXML
    {
        public static IRepository<Meeting> MeetingsRepository { get; } = new XMLMeetingsRepository();
        public static IRepository<Room> RoomsRepository { get; } = new XMLRoomRepository();
    }
}
