
namespace CalendarApp.Console.Presenters.Meetings
{
    internal class AddMeetingPresenter : IPresenter
    {
        private readonly IService<Meeting> _service;
        private readonly IService<Room> _rooms;

        public AddMeetingPresenter(IService<Meeting> service, IService<Room> rooms)
        {
            _service = service;
            _rooms = rooms;
        }

        public IPresenter Action()
        {
            Meeting meeting = CreateMeeting();
            if (meeting != null)
            {
                _service.Add(meeting);
                WriteLine("Success!");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
            return new MainMenuPresenter();
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

                var freeRooms = (from r in _rooms.GetAll()
                                 from s in r.Schedule
                                 where (start < s.Key || s.Value < start) && r.Schedule.All(x => x.Key > end || x.Value < start)
                                 select r).Distinct();


                if (freeRooms.Count() == 0)
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
                    WriteLine("Free rooms:");
                    foreach (var r in freeRooms)
                        WriteLine("\t Id: " + r.Id + " Capacity: " + r.Capacity);
                    WriteLine();
                    Write("Pick: ");
                    if (int.TryParse(ReadLine(), out id) || freeRooms.FirstOrDefault(r => r.Id == id) != null)
                    {
                        room = freeRooms.FirstOrDefault(r => r.Id == id);
                        room.Schedule.Add(start, end);
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
