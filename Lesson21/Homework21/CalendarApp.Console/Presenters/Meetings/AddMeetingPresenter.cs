using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;
using static CalendarApp.Console.Program;
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
            WriteLine("Enter meeting name (min 6 and max 25 characters)");
            var name = ReadLine();
            if (name.Length > 5 && name.Length <= 25)
            {
                WriteLine("All meetings we set for tomorrow :), Please enter the time ('hh')");
                var hour = ReadLine();

                DateTime time;
                if (int.TryParse(hour, out var value))
                {
                    if (value >= 0 && value <= 23)
                    {
                        time = DateTime.Today.AddDays(1).AddHours(value);
                    }
                    else
                    {
                        WriteLine("You entered wrong time, so time will be seted to 12:00");
                        time = DateTime.Today.AddDays(1).AddHours(12);

                        WriteLine("Press any key to continue...");
                        ReadKey();
                    }
                }
                else
                {
                    WriteLine("You entered wrong time, so time will be seted to 12:00");
                    time = DateTime.Today.AddDays(1).AddHours(12);

                    WriteLine("Press any key to continue...");
                    ReadKey();
                }

                Clear();
                WriteLine("Choose room:");
                bool flag = false;

                WriteLine("{0,-25}{1,-25}{2,-25}", "Room Name", "Capacity", "Have Projector");

                foreach (var room in CalendarApp.BLL.Factory.RoomsService.GetAll())
                {
                    foreach (var meeting in CalendarApp.BLL.Factory.MeetingsService.GetAll())
                    {

                        bool overlap = meeting.StartTime < time.AddHours(1) && time < meeting.EndTime;
                        if (meeting.MeetingRoom == room)
                        {
                            if (overlap)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("{0,-25}{1,-25}{2,-25}", room.Name, room.Capacity, room.IsProjector);
                                ForegroundColor = ConsoleColor.Green;
                                flag = true;
                                break;
                            }
                        }
                        //else
                        //{
                        //    ForegroundColor = ConsoleColor.Blue;
                        //    WriteLine(room.Name + "  " + room.Capacity + "  " + room.IsProjector);
                        //    ForegroundColor = ConsoleColor.Green;
                        //    break;
                        //}
                        //if (meeting.MeetingRoom == item && (meeting.EndTime. > time && meeting.StartTime <= time) || (meeting.EndTime > time && meeting.StartTime <= time) { } 
                    }
                    if (!flag)
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("{0,-25}{1,-25}{2,-25}", room.Name, room.Capacity, room.IsProjector);
                        ForegroundColor = ConsoleColor.Green;
                    }
                    flag = false;
                    //WriteLine(item.Name);
                }
                while (true)
                {
                    WriteLine("Please enter room name ('red' is ocupied for seted time), choose it ONLY if you want to FIGHT with another team :)");
                    var input = ReadLine();
                    Room theRoom = null;
                    foreach (var room in CalendarApp.BLL.Factory.RoomsService.GetAll())
                        if (room.Name == input)
                            theRoom = room;
                    if (theRoom == null)
                    {
                        WriteLine("You enterede wrong room name so try again");
                    }
                    else
                    {
                        _service.Add(new Meeting { Name = name, StartTime = time, EndTime = time.AddHours(1), MeetingRoom = theRoom });
                        WriteLine("You created new meeting!\n");
                        break;
                    }

                }




            }
            else WriteLine("Meeting Name is wrong size");

            WriteLine("Press any key to continue...");
            ReadKey();
            return mainMenuPresenter;
        }

        public void Show()
        {
            Clear();

            WriteLine("Enter meeting details:");
        }
    }
}
