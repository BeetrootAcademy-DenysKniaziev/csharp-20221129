
namespace CalendarApp.Console.Presenters
{
    internal class RWMainMenuPresenter : IPresenter
    {
        private IService<Meeting> _meetingsService;
        private IService<Room> _roomService;


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
                    return new AddMeetingPresenter(_meetingsService, _roomService as IRoomService, this);
                case ConsoleKey.D2:
                    return new AddRoomPresenter(_roomService, this);
                case ConsoleKey.D3:
                    return new GetAllMeetingsPresenter(_meetingsService, this);
                case ConsoleKey.D4:
                    return new GetAllRoomsPresenter(_roomService, this);
                case ConsoleKey.D5:
                    return new GetMeetingInSelectedRoomPresenter(_meetingsService, _roomService, this);
                case ConsoleKey.D6:
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
            WriteLine("3 - Get All Meetings");
            WriteLine("4 - Get All Rooms");
            WriteLine("5 - See booked meetings in selected room");
            WriteLine("6 - Switch on ReadOnly Menu");
            WriteLine("0 - Exit");
        }
    }
}
