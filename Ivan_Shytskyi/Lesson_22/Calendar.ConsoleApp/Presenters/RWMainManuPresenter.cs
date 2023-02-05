using Calendar.BLL.Services.Interface;
using Calendar.ConsoleApp.Presenters.Interface;
using Calendar.ConsoleApp.Presenters.Meetings;
using Calendar.ConsoleApp.Presenters.Rooms;
using Calendar.Contracts.Models;

namespace Calendar.ConsoleApp.Presenters
{
    internal class RWMainManuPresenter : IPresenter
    {
        private readonly IService<Meeting> _metingsService;
        private readonly IService<Room> _roomsService;
        private readonly int _check;
        public RWMainManuPresenter(IService<Meeting> metingsService, IService<Room> roomsService, int check)
        {
            _metingsService = metingsService;
            _roomsService = roomsService;
            _check = check;
        }
        public IPresenter Action()
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new GetAllMeetingsPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D2:
                    return new AddTestMeetingsPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D3:
                    return new GetAllRoomsPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D4:
                    return new AddRoomsPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D5:
                    return new BookMeetingPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D6:
                    return new SeeBookedMeetingsPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D0:
                    return null;
                default:
                    return this;
            }
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Select ation:");
            Console.WriteLine("1 - Get all meetings");
            Console.WriteLine("2 - Add meetings test system");
            Console.WriteLine("3 - Get all rooms");
            Console.WriteLine("4 - Add rooms");
            Console.WriteLine("5 - Book meeting");
            Console.WriteLine("6 - See Booked Meetings in selected room");
            Console.WriteLine("0 - Exit");
        }
    }
}
