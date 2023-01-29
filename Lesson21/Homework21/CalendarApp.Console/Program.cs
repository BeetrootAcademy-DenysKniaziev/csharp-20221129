using CalendarApp.Console.Presenters;
using CalendarApp.Console.Presenters.Interfaces;
using static System.Console;
using BLLFactory = CalendarApp.BLL.Factory;

namespace CalendarApp.Console
{
    internal class Program
    {
        public static IPresenter mainMenuPresenter = new MainMenuPresenter(BLLFactory.MeetingsService, BLLFactory.RoomsService);
        static void Main(string[] args)
        {
            IPresenter presenter = mainMenuPresenter;
            while (presenter != null)
            {
                try
                {
                    presenter.Show();
                    presenter = presenter.Action();
                }
                catch (Exception Ex) { WriteLine("Someting goes wrong. Check this out:\n" + Ex.Message); }
            }
        }
    }
}