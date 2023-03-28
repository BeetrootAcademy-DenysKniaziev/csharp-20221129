using Calendar.BLL.Services.Interface;
using Calendar.ConsoleApp.Presenters.Interface;
using Calendar.Contracts.Models;

namespace Calendar.ConsoleApp.Presenters.Rooms
{
    internal class BookMeetingPresenter : IPresenter
    {
        private readonly IService<Meeting> _serviceMeeting;
        private readonly IService<Room> _serviceRoom;
        private readonly int _check;
        public BookMeetingPresenter(IService<Meeting> serviceMeeting, IService<Room> serviceRoom, int check)
        {
            _serviceMeeting = serviceMeeting;
            _serviceRoom = serviceRoom;
            _check = check;
        }
        public IPresenter Action()
        {
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            foreach (var room in _serviceRoom.GetAll())
            {
                string c = room.Id.ToString();
                if (id == c)
                {
                    Console.Write("Enter name meeting: ");
                    string nameMeeting = Console.ReadLine();
                    string name = room.RoomName;
                    Console.Write("Enter start time: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    DateTime dt = new DateTime();
                    dt = dt.AddHours(a);
                    Console.Write("Enter end time: ");
                    int b = Convert.ToInt32(Console.ReadLine());
                    DateTime dt1 = new DateTime();
                    dt1 = dt1.AddHours(b);
                    _serviceMeeting.Add(new Meeting(nameMeeting, dt, dt1, id, name));
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    if (_check == 1)
                        return new MainManuPresenter(_serviceMeeting, _serviceRoom, _check);
                    else
                        return new RWMainManuPresenter(_serviceMeeting, _serviceRoom, _check);

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
            Console.WriteLine("All rooms:");
            Console.WriteLine("{0,-40} {1,-40}", "ID", "Name");
            foreach (var room in _serviceRoom.GetAll())
            {
                Console.WriteLine("{0,-40} {1,-40}", room.Id, room.RoomName);
            }
        }
    }
}
