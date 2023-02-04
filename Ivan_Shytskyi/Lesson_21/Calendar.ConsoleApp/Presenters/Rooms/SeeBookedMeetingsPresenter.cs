using Calendar.BLL.Services.Interface;
using Calendar.ConsoleApp.Presenters.Interface;
using Calendar.Contracts.Models;

namespace Calendar.ConsoleApp.Presenters.Rooms
{
    internal class SeeBookedMeetingsPresenter : IPresenter
    {
        private readonly IService<Meeting> _serviceMeeting;
        private readonly IService<Room> _serviceRoom;
        private readonly int _check;
        public SeeBookedMeetingsPresenter(IService<Meeting> serviceMeeting, IService<Room> serviceRoom, int check)
        {
            _serviceMeeting = serviceMeeting;
            _serviceRoom = serviceRoom;
            _check = check;
        }
        public IPresenter Action()
        {
            Console.Write("Select room: ");
            string name = Console.ReadLine();
            foreach (var room in _serviceRoom.GetAll())
            {
                Console.Clear();
                Console.WriteLine("{0,-25} {1,-25} {2,-25} {3,-25}", "Name", "Start time", "End time", "Room name");
                foreach (var meeting in _serviceMeeting.GetAll())
                {
                    if (name == meeting.Room)
                    {
                        Console.WriteLine("{0,-25} {1,-25} {2,-25} {3,-25}", meeting.Name, meeting.StartTime, meeting.EndTime, meeting.Room);
                    }
                }
            }
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
            Console.WriteLine("{0,-25}", "Name");
            foreach (var room in _serviceRoom.GetAll())
            {
                Console.WriteLine("{0,-25}", room.RoomName);
            }
        }
    }
}
