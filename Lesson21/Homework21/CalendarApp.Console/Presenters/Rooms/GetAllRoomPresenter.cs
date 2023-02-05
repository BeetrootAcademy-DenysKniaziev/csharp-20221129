using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CalendarApp.Console.Presenters.Rooms
{
    internal class GetAllRoomPresenter : IPresenter
    {
        private readonly IService<Room> _service;

        public GetAllRoomPresenter(IService<Room> service)
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
        }
    }
}
