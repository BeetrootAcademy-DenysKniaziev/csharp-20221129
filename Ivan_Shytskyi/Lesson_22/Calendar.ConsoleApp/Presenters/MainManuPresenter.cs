using Calendar.BLL.Services.Interface;
using Calendar.Contracts.Models;
using Calendar.ConsoleApp.Presenters.Interface;
using Calendar.ConsoleApp.Presenters.Meetings;
using Calendar.ConsoleApp.Presenters.Rooms;

namespace Calendar.ConsoleApp.Presenters
{
    internal class MainManuPresenter : IPresenter
    {
        private readonly IService<Meeting> _metingsService;
        private readonly IService<Room> _roomsService;
        private readonly int _check;
        public MainManuPresenter(IService<Meeting> metingsService, IService<Room> roomsService, int check)
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
                    return new GetAllRoomsPresenter(_metingsService, _roomsService, _check);
                case ConsoleKey.D3:
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
            Console.WriteLine("2 - Get all rooms");
            Console.WriteLine("3 - See Booked Meetings in selected room");
            Console.WriteLine("0 - Exit");
        }
    }
}
