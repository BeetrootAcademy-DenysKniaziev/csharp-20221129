using CalendarApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.DAL
{
    public class FactoryCSV
    {
        public static IRepository<Meeting> MeetingsRepository { get; } = new CSVMeetingRepository();
        public static IRepository<Room> RoomsRepository { get; } = new CSVRoomRepository();
    }
}
