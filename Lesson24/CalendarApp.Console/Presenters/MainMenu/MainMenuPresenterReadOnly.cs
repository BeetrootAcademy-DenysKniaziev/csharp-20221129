using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Console.Presenters.Meetings;
using CalendarApp.Console.Presenters.Rooms;
using CalendarApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

[assembly: InternalsVisibleTo("CalendarApp.Console.Tests")]
namespace CalendarApp.Console.Presenters.MainMenu
{
    internal class MainMenuPresenterReadOnly : IPresenter
    {
        private readonly IService<Meeting> _meetingService;
        private readonly IService<Room> _roomService;

        public MainMenuPresenterReadOnly(IService<Meeting> meetingService, IService<Room> roomService)
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
                    return new GetAllRoomPresenter(_roomService);
                case ConsoleKey.D3:
                    return new GetScheduleForRoom(_roomService);

                case ConsoleKey.D4:
                    {
                        Program.mainMenuPresenter = new MainMenuPresenter(_meetingService, _roomService);
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
            WriteLine("2 - Show All Rooms");
            WriteLine("3 - Get Schedule For All Rooms");
            WriteLine("4 - Switch To Read/Write Mode");
            WriteLine("0 - Exit");
        }
    }
}
