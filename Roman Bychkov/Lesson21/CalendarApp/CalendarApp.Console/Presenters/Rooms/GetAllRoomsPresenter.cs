
namespace CalendarApp.Console.Presenters.Meetings
{
    internal class GetAllRoomsPresenter : IPresenter
    {
        private readonly IService<Room> _service;
        private readonly IPresenter _presenter;

        public GetAllRoomsPresenter(IService<Room> service, IPresenter sender)
        {
            _service = service;
            _presenter = sender;
        }

        public IPresenter Action()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
            return _presenter;
        }

        public void Show()
        {
            Clear();

            foreach (var room in _service.GetAll())
            {
                WriteLine("{0,-60}{1,-25}{2,-25}", "Id", "Capacity", "Taken");
                Write("{0,-60}{1,-25}{2,-25}", room.Id, room.Capacity, "");
                WriteLine();
                foreach (var item in room.Schedule)
                    Write($"{item.Start,70} - {item.End}\n");
            }
          
        }
    }
}
