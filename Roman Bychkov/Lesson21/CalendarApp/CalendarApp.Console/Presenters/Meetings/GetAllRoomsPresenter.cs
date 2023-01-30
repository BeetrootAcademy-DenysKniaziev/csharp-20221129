using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Contracts.Models;

using static System.Console;

namespace CalendarApp.Console.Presenters.Meetings
{
    internal class GetAllRoomsPresenter : IPresenter
    {
        private readonly IService<Room> _service;

        public GetAllRoomsPresenter(IService<Room> service)
        {
            _service = service;
        }

        public IPresenter Action()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
            return new MainMenuPresenter();
        }

        public void Show()
        {
            Clear();

            WriteLine("{0,-25}{1,-25}{2,-25}", "Id", "Capacity", "Status");
            foreach (var room in _service.GetAll())
            {
                WriteLine("{0,-25}{1,-25}{2,-25}", room.Id, room.Capacity, room.IsFree);
            }
        }
    }
}
