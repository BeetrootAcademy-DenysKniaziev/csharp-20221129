namespace CalendarApp.Console.Presenters.Meetings
{
    internal class AddRoomPresenter : IPresenter
    {
        private readonly IService<Room> _service;
        private readonly IPresenter _presenter;
        public AddRoomPresenter(IService<Room> service, IPresenter sender)
        {
            _service = service;
            _presenter = sender;
        }
        public IPresenter Action()
        {
            _service.Add(new Room(ValidCapacity()));
            WriteLine("Press any key to continue...");
            ReadKey();
            return _presenter;
        }

        public void Show()
        {
            Clear();
            WriteLine("Enter the capacity of the room: ");
        }
        public int ValidCapacity()
        {
           
            while (true)
            {
                if (int.TryParse(ReadLine(), out int capacity) && capacity > 0)
                    return capacity;
                else
                    WriteLine("Invalid capacity.");
            }
        }
    }
}
