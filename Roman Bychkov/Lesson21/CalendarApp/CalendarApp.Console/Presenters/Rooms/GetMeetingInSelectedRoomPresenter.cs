namespace CalendarApp.Console.Presenters.Meetings
{
    internal class GetMeetingInSelectedRoomPresenter : IPresenter
    {

        private readonly IService<Meeting> _meetingService;
        private readonly IService<Room> _roomService;
        private readonly IPresenter _presenter;

        public GetMeetingInSelectedRoomPresenter(IService<Meeting> meetingService, IService<Room> roomService, IPresenter sender)
        {
            _meetingService = meetingService;
            _roomService = roomService;
            _presenter = sender;
        }

        public IPresenter Action()
        {
            var meetings = SearchRoom();
            if (meetings.Count() != 0)
            {
                Clear();

                WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", "Name", "Start Time", "End Time", "Room Id");
                foreach (var meeting in meetings)
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
            return _presenter;
        }

        public void Show()
        {
            Clear();
            WriteLine("Enter the room's ID");
        }
        public IEnumerable<Meeting> SearchRoom()
        {
            Room room = null;
            while (true)
            {
                var rooms = _roomService.GetAll().ToList();
                if (rooms.Count == 0)
                    break;
                WriteLine("Rooms:");
                for (int i = 1; i <= rooms.Count(); i++)
                    WriteLine("\t  " + i + " Capacity: " + rooms[i - 1].Capacity);
                WriteLine();
                Write("Pick: ");
                if (int.TryParse(ReadLine(), out int id) && id > 0 && id <= rooms.Count)
                {
                    room = rooms.FirstOrDefault(r => r.Equals(rooms[id - 1]));
                    break;
                }
                else
                {
                    Clear();
                }
            }
            return _meetingService.GetAll().Where(m => m.Room.Equals(room));

        }
    }
}
