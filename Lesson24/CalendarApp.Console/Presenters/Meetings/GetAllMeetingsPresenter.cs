using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;
using System.Runtime.CompilerServices;
using static System.Console;

[assembly: InternalsVisibleTo("CalendarApp.Console.Tests")]
namespace CalendarApp.Console.Presenters.Meetings
{
    internal class GetAllMeetingsPresenter : IPresenter
    {
        private readonly IService<Meeting> _service;

        public GetAllMeetingsPresenter(IService<Meeting> service)
        {
            _service = service;
        }

        public IPresenter Action()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
            return Program.mainMenuPresenter;
        }

        public void Show()
        {
            Clear();

            WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", "Name", "Start Time", "End Time", "Room Name");
            foreach (var meeting in _service.GetAll())
            {
                WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", meeting.Name, meeting.StartTime, meeting.EndTime, meeting.MeetingRoom.Name);
            }
        }
    }
}
