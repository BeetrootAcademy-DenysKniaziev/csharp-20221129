using Calendar.ConsoleApp.Presenters;
using Calendar.ConsoleApp.Presenters.Interface;
using BLLFactory = Calendar.BLL.Factory;
//using BLLRoomFactory = Calendar.BLL.RoomFactory;

namespace Calendar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you?");
            Console.WriteLine("1 - User\n2 - Admin");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                IPresenter presenter = new MainManuPresenter(BLLFactory.meetingsService, BLLFactory.roomsService, a);
                while (presenter != null)
                {
                    presenter.Show();
                    presenter = presenter.Action();
                }
            }
            else if (a == 2)
            {
                IPresenter presenter = new RWMainManuPresenter(BLLFactory.meetingsService, BLLFactory.roomsService, a);
                while (presenter != null)
                {
                    presenter.Show();
                    presenter = presenter.Action();
                }
            }
        }
    }
}