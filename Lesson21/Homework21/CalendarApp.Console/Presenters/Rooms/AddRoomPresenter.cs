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
    internal class AddRoomPresenter : IPresenter
    {
        private readonly IService<Room> _service;

        public AddRoomPresenter(IService<Room> service)
        {
            _service = service;
        }

        IPresenter IPresenter.Action()
        {

            //TODO: Add logic
            WriteLine("Enter room name (min 1 and max 15 characters)");
            var name = ReadLine();
            if (name.Length > 0 && name.Length <= 15 && _service.GetAll().Select(r => r.Name).Contains(name) == false)
                _service.Add(new Room { Name = name, Capacity = new Random().Next(5, 25), IsProjector = Convert.ToBoolean(new Random().Next(0, 2)) });
            else WriteLine("Wrong name or Name Exist\n");

            WriteLine("Press any key to continue...");
            ReadKey();
            return Program.mainMenuPresenter;
        }

        void IPresenter.Show()
        {
            Clear();

            WriteLine("Enter room details:");
        }
    }
}
