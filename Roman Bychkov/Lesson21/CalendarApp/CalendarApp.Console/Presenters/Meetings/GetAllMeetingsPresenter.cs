
namespace CalendarApp.Console.Presenters.Meetings
{
    internal class GetAllMeetingsPresenter : IPresenter
    {
        private readonly IService<Meeting> _service;
        private readonly IPresenter _presenter;

        public GetAllMeetingsPresenter(IService<Meeting> service, IPresenter sender)
        {
            _service = service;
            _presenter = sender;
        }

        public IPresenter Action()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
            return _presenter;
        }

        public void Show()
        {
            Clear();

            WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", "Name", "Start Time", "End Time", "Room Id");
            foreach (var meeting in _service.GetAll())
            {
                WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", meeting.Name, meeting.StartTime, meeting.EndTime, meeting.Room?.Id);
            }
        }
    }
}
