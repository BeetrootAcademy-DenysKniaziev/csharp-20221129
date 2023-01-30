
namespace CalendarApp.Console.Presenters
{
    internal class RWMainMenuPresenter : IPresenter
    {
        private readonly IService<Meeting> _meetingsService = BLLFactory.Factory.MeetingsService;
        private readonly IService<Room> _roomService = BLLFactory.FactoryRoom.RoomService;

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
                    return new ReadOnlyMenuPresenter();
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
