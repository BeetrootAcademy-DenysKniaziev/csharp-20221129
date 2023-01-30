namespace CalendarApp.Console.Presenters.Meetings
{
    internal class GetMeetingInSelectedRoomPresenter : IPresenter
    {

        private readonly IService<Meeting> _service;

        public GetMeetingInSelectedRoomPresenter(IService<Meeting> service)
        {
            _service = service;
        }

        public IPresenter Action()
        {
            var meetings = SearchRoom();
            if (meetings.Count() != 0)
            {
                Clear();

                WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", "Name", "Start Time", "End Time", "Room Id");
                foreach (var meeting in _service.GetAll())
                {
                    WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", meeting.Name, meeting.StartTime, meeting.EndTime, meeting.Room?.Id);
                }
            }
            else
            {
                WriteLine("Meetings not found");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
            return new MainMenuPresenter();
        }

        public void Show()
        {
            Clear();
            WriteLine("Enter the room's ID");
            WriteLine();
        }
        public IEnumerable<Meeting> SearchRoom()
        {
            while (true)
            {
                if (int.TryParse(ReadLine(), out int id) || id < 0)
                    return _service.GetAll().Where(m => m.Room?.Id == id);
                else
                    WriteLine("Invalid id.");
            }
        }
    }
}
