using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace CalendarApp.Console.Presenters.Rooms
{
    internal class GetScheduleForRoom : IPresenter
    {
        private readonly IService<Room> _service;

        public GetScheduleForRoom(IService<Room> service)
        {
            _service = service;
        }

        IPresenter IPresenter.Action()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
            return Program.mainMenuPresenter;
        }

        void IPresenter.Show()
        {
            Clear();

            WriteLine("{0,-25}{1,-25}{2,-25}", "Room Name", "Capacity", "Projector");
            foreach (var room in _service.GetAll())
            {
                WriteLine("{0,-25}{1,-25}{2,-25}", room.Name, room.Capacity, room.IsProjector.ToString());
            }

            WriteLine("\nPlease enter room name");
            var input = ReadLine();
            if (_service.GetAll().Select(rn => rn.Name).Contains(input))
            {
                WriteLine("\n{0,-25}{1,-25}{2,-25}{3,-25}", "Meeting Name", "Start Time", "End Time", "Room Name");
                foreach (var meeting in CalendarApp.BLL.Factory.MeetingsService.GetAll())
                {
                    if (meeting.MeetingRoom.Name == input)
                    {
                        WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", meeting.Name, meeting.StartTime, meeting.EndTime, meeting.MeetingRoom.Name);
                    }
                }
            }
            else WriteLine("Wrong room name");
        }
    }
}

