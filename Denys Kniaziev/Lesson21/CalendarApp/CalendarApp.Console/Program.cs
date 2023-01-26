using CalendarApp.Console.Presenters;
using CalendarApp.Console.Presenters.Interfaces;

using BLLFactory = CalendarApp.BLL.Factory;

namespace CalendarApp.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPresenter presenter = new MainMenuPresenter(BLLFactory.MeetingsService);

            while (presenter != null)
            {
                presenter.Show();
                presenter = presenter.Action();
            }
        }
    }
}