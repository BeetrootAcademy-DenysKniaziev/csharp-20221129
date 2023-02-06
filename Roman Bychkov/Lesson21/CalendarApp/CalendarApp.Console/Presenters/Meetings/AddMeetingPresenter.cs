
namespace CalendarApp.Console.Presenters.Meetings
{
    internal class AddMeetingPresenter : IPresenter
    {
        private readonly IService<Meeting> _metingservice;
        private readonly IService<Room> _roomsservice;
        private readonly IPresenter _presenter;

        public AddMeetingPresenter(IService<Meeting> service, IService<Room> rooms, IPresenter sender)
        {
            _metingservice = service;
            _roomsservice = rooms;
            _presenter = sender;
        }

        public IPresenter Action()
        {
            Meeting meeting = CreateMeeting();
            if (meeting != null)
            {
                _metingservice.Add(meeting);
                meeting.Room.Schedule.Add(new TimeRange(meeting.StartTime, meeting.EndTime));
                _roomsservice.Update(meeting.Room);
                WriteLine("Success!");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
            return _presenter;
        }

        public void Show()
        {
            Clear();
            WriteLine("Enter meeting details:");
        }
        private Meeting CreateMeeting()
        {

            string name;
            DateTime start, end;
            int id;
            Room room = null;

            while (true)
            {
                Write("Name: ");
                name = ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    WriteLine("Invalid name");
                    continue;
                }
                break;
            }
            while (true)
            {
                Write("Start time: ");
                if (!DateTime.TryParse(ReadLine(), out start) || start == DateTime.MinValue)
                {
                    WriteLine("Invalid start time");
                    continue;
                }
                break;
            }
            while (true)
            {
                Write("End time: ");
                if (!DateTime.TryParse(ReadLine(), out end) || end == DateTime.MinValue || end <= start)
                {
                    WriteLine("Invalid end time");
                    continue;
                }
                break;
            }
            while (true)
            {

                if (_roomsservice.GetFreeRooms(start, end).Count() == 0)
                {
                    WriteLine("Free room is not exist. Wait until some room is free or go back to the main menu? y/n");
                    while (true)
                    {
                        var key = ReadKey().Key;
                        if (key == ConsoleKey.N)
                            return null;
                        if (key == ConsoleKey.Y)
                            break;
                    }

                }
                else
                {
                    while (true)
                    {
                        WriteLine("Free rooms:");
                        foreach (var r in _roomsservice.GetFreeRooms(start, end))
                            WriteLine("\t Id: " + r.Id + " Capacity: " + r.Capacity);
                        WriteLine();
                        Write("Pick: ");
                        if (int.TryParse(ReadLine(), out id) && _roomsservice.GetFreeRooms(start, end).FirstOrDefault(r => r.Id == id) != null)
                        {
                            room = _roomsservice.GetFreeRooms(start, end).FirstOrDefault(r => r.Id == id);
                            break;
                        }
                        else
                        {
                            Clear();
                        }
                    }
                    return new Meeting()
                    {
                        Name = name,
                        StartTime = start,
                        EndTime = end,
                        Room = room
                    };
                }

            }
        }
    }
}

