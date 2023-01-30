
namespace CalendarApp.Console.Presenters
{
    internal class RWMainMenuPresenter : IPresenter
    {
        private static IService<Meeting> _meetingsService;
        private static IService<Room> _roomService;

        public RWMainMenuPresenter()
        {

        }
        public RWMainMenuPresenter(IService<Meeting> meetingsService, IService<Room> roomService)
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
                    return new AddMeetingPresenter(_meetingsService, _roomService);
                case ConsoleKey.D2:
                    return new AddRoomPresenter(_roomService);
                case ConsoleKey.D3:
                    return new ReadOnlyMenuPresenter(_meetingsService, _roomService);
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
            WriteLine("1 - Add Meeting");
            WriteLine("2 - Add Room");
            WriteLine("3 - Switch on ReadOnly Menu");
            WriteLine("0 - Exit");
        }
    }
}
