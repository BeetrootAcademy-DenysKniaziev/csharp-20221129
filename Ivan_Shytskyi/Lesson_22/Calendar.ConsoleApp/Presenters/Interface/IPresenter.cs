namespace Calendar.ConsoleApp.Presenters.Interface
{ 
    internal interface IPresenter
    {
        void Show();
        IPresenter Action();
    }

}
