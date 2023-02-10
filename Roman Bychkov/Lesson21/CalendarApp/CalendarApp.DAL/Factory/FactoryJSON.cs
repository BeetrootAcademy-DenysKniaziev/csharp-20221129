namespace CalendarApp.DAL
{
    public static class FactoryJSON
    {
        public static IRepository<Meeting> MeetingsRepository { get; } = new JSONMeetingsRepository();
        public static IRepository<Room> RoomsRepository { get; } = new JSONRoomRepository();

    }
}
