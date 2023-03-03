using Calendar.BLL.Services.Interface;
using Calendar.ConsoleApp.Presenters.Interface;
using Calendar.Contracts.Models;

namespace Calendar.ConsoleApp.Presenters.Meetings
{
    // class book meeting add new meeting
    internal class AddTestMeetingsPresenter : IPresenter
    {
        private readonly IService<Meeting> _serviceMeeting;
        private readonly IService<Room> _serviceRoom;
        private readonly int _check;

        public AddTestMeetingsPresenter(IService<Meeting> serviceMeeting, IService<Room> serviceRoom, int check)
        {
            _serviceMeeting = serviceMeeting;
            _serviceRoom = serviceRoom;
            _check = check;
        }

        public IPresenter Action()
        {
            _serviceMeeting.Add(new Meeting("Dummy Meeting", DateTime.UtcNow, DateTime.Now, "1", "black"));
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
            Console.WriteLine("Enter meeting details:");
        }
    }
}
