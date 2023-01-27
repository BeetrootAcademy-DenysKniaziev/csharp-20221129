using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Console.Presenters.Meetings;
using CalendarApp.Contracts.Models;
using static System.Console;

namespace CalendarApp.Console.Presenters
{
    internal class MainMenuPresenter : IPresenter
    {
        private readonly IService<Meeting> _meetingsService;

        public MainMenuPresenter(IService<Meeting> meetingsService)
        {
            _meetingsService = meetingsService;
        }

        public IPresenter Action()
        {
            var key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new GetAllMeetingsPresenter(_meetingsService);
                case ConsoleKey.D2:
                    return new AddMeetingPresenter(_meetingsService);
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
            WriteLine("0 - Exit");
        }
    }
}
