
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
            return new ReadOnlyMenuPresenter();
        }

        public void Show()
        {
            Clear();

            foreach (var room in _service.GetAll())
            {
                WriteLine("{0,-25}{1,-25}{2,-25}", "Id", "Capacity", "Taken");
                Write("{0,-25}{1,-25}{2,-25}", room.Id, room.Capacity, "");
                WriteLine();
                foreach (var item in room.Schedule)
                    Write($"{item.Key,70} - {item.Value}\n");
            }
            WriteLine();
        }
    }
}
