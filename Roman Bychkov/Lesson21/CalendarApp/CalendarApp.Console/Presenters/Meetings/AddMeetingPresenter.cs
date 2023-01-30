using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;

using static System.Console;

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
                if (_rooms.GetAll().Count(x => x.IsFree) == 0)
                {
                    WriteLine("Free room not exist. Wait until some room is free or go back to the main menu? y/n");
                    while (true)
                    {
                        if (ReadKey().Key == ConsoleKey.N)
                            return null;
                        if (ReadKey().Key == ConsoleKey.Y)
                            continue;
                    }

                }
                else
                {
                    WriteLine("Free rooms:");
                    foreach (var r in _rooms.GetAll().Where(r => r.IsFree))
                        WriteLine("\t Id: " + r.Id);
                    WriteLine();
                    Write("Pick: ");
                    if (int.TryParse(ReadLine(), out id) || _rooms.GetAll().FirstOrDefault(r => r.Id == id && r.IsFree) != null)
                    {
                        room = _rooms.GetAll().FirstOrDefault(r => r.Id == id && r.IsFree);
                        room.IsFree = false;
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
