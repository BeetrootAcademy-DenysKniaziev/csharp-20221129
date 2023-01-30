
namespace CalendarApp.Console.Presenters.Meetings
{
    internal class AddMeetingPresenter : IPresenter
    {
        private readonly IService<Meeting> _metingservice;
        private readonly IService<Room> _roomsservice;

        public AddMeetingPresenter(IService<Meeting> service, IService<Room> rooms)
        {
            _metingservice = service;
            _roomsservice = rooms;
        }

        public IPresenter Action()
        {
            Meeting meeting = CreateMeeting();
            if (meeting != null)
            {
                _metingservice.Add(meeting);
                WriteLine("Success!");
            }
            WriteLine("Press any key to continue...");
            ReadKey();
            return new RWMainMenuPresenter();
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

                var freeRooms = (from r in _roomsservice.GetAll()
                                 from s in r.Schedule
                                 where (start < s.Key || s.Value < start) && r.Schedule.All(x => x.Key > end || x.Value < start) || r.Schedule.Count() == 0
                                 select r).Distinct().Union(_roomsservice.GetAll().Where(r => r.Schedule.Count == 0));


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
                        _roomsservice.Update(room);
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
