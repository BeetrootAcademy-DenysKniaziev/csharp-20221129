using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Console.Presenters.Meetings;
using CalendarApp.Contracts.Models;
using static System.Console;
using BLLFactory = CalendarApp.BLL;

namespace CalendarApp.Console.Presenters
{
    internal class MainMenuPresenter : IPresenter
    {

        private readonly IService<Meeting> _meetingsService = BLLFactory.Factory.MeetingsService;
        private readonly IService<Room> _roomService = BLLFactory.FactoryRoom.RoomService;

        public IPresenter Action()
        {
            var key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new GetAllMeetingsPresenter(_meetingsService);
                case ConsoleKey.D2:
                    return new AddMeetingPresenter(_meetingsService, _roomService);
                case ConsoleKey.D3:
                    return new GetAllRoomsPresenter(_roomService);
                case ConsoleKey.D4:
                    return new AddRoomPresenter(_roomService);
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
            WriteLine("2 - Add Meeting");
            WriteLine("3 - Get All Rooms");
            WriteLine("4 - Add Room");
            WriteLine("0 - Exit");
        }
    }
}