using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;

using static System.Console;

namespace CalendarApp.Console.Presenters.Meetings
{
    internal class AddMeetingPresenter : IPresenter
    {
        private readonly IService<Meeting> _service;

        public AddMeetingPresenter(IService<Meeting> service)
        {
            _service = service;
        }

        public IPresenter Action()
        {
            //TODO: Add logic
            _service.Add(new Meeting { Name = "Dummy Meeting", RoomName = @"Green,  ""Room""" });

            WriteLine("Press any key to continue...");
            ReadKey();
            return new MainMenuPresenter(_service);
        }

        public void Show()
        {
            Clear();

            WriteLine("Enter meeting details:");
        }
    }
}
