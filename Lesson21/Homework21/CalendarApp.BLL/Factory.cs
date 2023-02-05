﻿using CalendarApp.BLL.Services;
using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;

using DALFactory = CalendarApp.DAL.Factory;

namespace CalendarApp.BLL
{
    public static class Factory
    {
        public static IService<Meeting> MeetingsService { get; } = new MeetingsService(DALFactory.MeetingsRepository);
        public static IService<Room> RoomsService { get; } = new RoomsService(DALFactory.RoomsRepository);
    }
}
