namespace CalendarApp.Console.Presenters
{
    internal class ReadOnlyMenuPresenter : IPresenter
    {
        private static IService<Meeting> _meetingsService;
        private static IService<Room> _roomService;

        public ReadOnlyMenuPresenter()
        {

        }
        public ReadOnlyMenuPresenter(IService<Meeting> meetingsService, IService<Room> roomService)
        {
            _meetingsService = meetingsService;
            _roomService = roomService;
        }
        public IPresenter Action()
        {
            var key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new GetAllMeetingsPresenter(_meetingsService);
                case ConsoleKey.D2:
                    return new GetAllRoomsPresenter(_roomService);
                case ConsoleKey.D3:
                    return new GetMeetingInSelectedRoomPresenter(_meetingsService);
                case ConsoleKey.D4:
                    return new RWMainMenuPresenter(_meetingsService, _roomService);
                case ConsoleKey.D0:
                    return null;
                default:
                    return this;
            }
        }

        public void Show()
        {
            Clear();

            WriteLine("Select Action:");
            WriteLine("1 - Get All Meetings");
            WriteLine("2 - Get All Rooms");
            WriteLine("3 - See booked meetings in selected room");
            WriteLine("4 - Switch on RW Menu");
            WriteLine("0 - Exit");

        }
    }
}