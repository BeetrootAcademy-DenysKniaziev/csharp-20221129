﻿using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using Calendar.DAL.Repositorys;

namespace Calendar.DAL
{
    public static class RoomFactory
    {
        public static IRepository<Room> RoomsRepository { get; } = new RoomsRepository();
    }
}
