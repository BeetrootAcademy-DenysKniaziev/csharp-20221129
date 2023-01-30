﻿
namespace CalendarApp.Console.Presenters
{
    internal class RWMainMenuPresenter : IPresenter
    {
        private readonly IService<Meeting> _meetingsService = BLLFactory.Factory.MeetingsService;
        private readonly IService<Room> _roomService = BLLFactory.FactoryRoom.RoomService;

        public IPresenter Action()
        {
            var key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new GetAllMeetingsPresenter(_meetingsService);
               case ConsoleKey.D2:
                    return new GetAllRoomsPresenter(_roomService);
                case ConsoleKey.D3:
                    return new GetMeetingInSelectedRoomPresenter(_meetingsService);
                case ConsoleKey.D4:
                    return new ReadOnlyMenuPresenter();
                case ConsoleKey.D0:
                    return null;
                default:
                    return this;
            }
        }

        public void Show()
        {
            Clear();

            WriteLine("Select Action:");
            WriteLine("1 - Get All Meetings");
            WriteLine("2 - Get All Rooms");
            WriteLine("3 - See booked meetings in selected room");
            WriteLine("3 - Switch on ReadOnly Menu");

        }
    }
}
