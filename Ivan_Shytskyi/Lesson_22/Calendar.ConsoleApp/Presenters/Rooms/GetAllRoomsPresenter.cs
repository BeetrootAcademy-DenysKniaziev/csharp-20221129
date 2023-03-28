using Calendar.BLL.Services.Interface;
using Calendar.ConsoleApp.Presenters.Interface;
using Calendar.Contracts.Models;

namespace Calendar.ConsoleApp.Presenters.Rooms
{
    internal class GetAllRoomsPresenter : IPresenter
    {
        private readonly IService<Meeting> _serviceMeeting;
        private readonly IService<Room> _serviceRoom;
        private readonly int _check;
        public GetAllRoomsPresenter(IService<Meeting> serviceMeeting, IService<Room> serviceRoom, int check)
        {
            _serviceMeeting = serviceMeeting;
            _serviceRoom = serviceRoom;
            _check = check;
        }
        public IPresenter Action()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            if (_check == 1)
                return new MainManuPresenter(_serviceMeeting, _serviceRoom, _check);
            else
                return new RWMainManuPresenter(_serviceMeeting, _serviceRoom, _check);
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("{0,-40} {1,-40}", "ID", "Name");
            foreach (var room in _serviceRoom.GetAll())
            {
                Console.WriteLine("{0,-40} {1,-40}", room.Id, room.RoomName);
            }
        }
    }
}
