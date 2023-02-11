﻿using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories;
using CalendarApp.DAL.Repositories.Interfaces;

namespace CalendarApp.DAL
{
    public static class Factory
    {
        public static IRepository<Meeting> MeetingsRepository { get; } = new MeetingsRepository();
        public static IRepository<Room> RoomsRepository { get; } = new RoomsRepository();
    }
}
