using CalendarApp.Console.Presenters;



namespace CalendarApp.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPresenter presenter = new ReadOnlyMenuPresenter(BLLFactory.Factory.MeetingsService, BLLFactory.FactoryRoom.RoomService);

            while (presenter != null)
            {
                presenter.Show();
                presenter = presenter.Action();
            }
        }
    }
}