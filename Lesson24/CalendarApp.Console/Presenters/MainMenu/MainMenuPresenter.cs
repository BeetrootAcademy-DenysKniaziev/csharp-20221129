using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Console.Presenters.Meetings;
using CalendarApp.Console.Presenters.Rooms;
using CalendarApp.Contracts.Models;
using System.Runtime.CompilerServices;
using static System.Console;

[assembly: InternalsVisibleTo("CalendarApp.Console.Tests")]
namespace CalendarApp.Console.Presenters.MainMenu
{
    internal class MainMenuPresenter : IPresenter
    {
        private readonly IService<Meeting> _meetingService;
        private readonly IService<Room> _roomService;

        public MainMenuPresenter(IService<Meeting> meetingService, IService<Room> roomService)
        {
            _meetingService = meetingService;
            _roomService = roomService;
        }

        public IPresenter Action()
        {
            var key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new GetAllMeetingsPresenter(_meetingService);
                case ConsoleKey.D2:
                    return new AddMeetingPresenter(_meetingService);
                case ConsoleKey.D3:
                    return new GetAllRoomPresenter(_roomService);
                case ConsoleKey.D4:
                    return new AddRoomPresenter(_roomService);
                case ConsoleKey.D5:
                    return new GetScheduleForRoom(_roomService);

                case ConsoleKey.D6:
                    {
                        Program.mainMenuPresenter = new MainMenuPresenterReadOnly(_meetingService, _roomService);
                    }
                    return Program.mainMenuPresenter;


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
            WriteLine("1 - Show All Meetings");
            WriteLine("2 - Book New Meeting");
            WriteLine("3 - Show All Rooms");
            WriteLine("4 - Add Room");
            WriteLine("5 - Get Schedule For All Rooms");
            WriteLine("6 - Switch To ReadOnly Mode");
            WriteLine("0 - Exit");
        }
    }
}
