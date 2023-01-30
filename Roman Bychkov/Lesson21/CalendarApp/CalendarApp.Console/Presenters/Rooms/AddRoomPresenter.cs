namespace CalendarApp.Console.Presenters.Meetings
{
    internal class AddRoomPresenter : IPresenter
    {
        private readonly IService<Room> _service;

        public AddRoomPresenter(IService<Room> service)
        {
            _service = service;
        }

        public IPresenter Action()
        {
            _service.Add(new Room { Capacity = ValidCapacity() });
            WriteLine("Press any key to continue...");
            ReadKey();
            return new MainMenuPresenter();
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
