using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Linq;

namespace CalendarApp.DAL
{
    public static class Factory
    {
        public static IRepository<Meeting> MeetingsRepository { get; } = new JSONMeetingsRepository();

    }
}
