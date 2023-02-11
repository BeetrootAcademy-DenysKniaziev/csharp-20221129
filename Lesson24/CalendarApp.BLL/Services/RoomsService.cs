using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace CalendarApp.BLL.Services
{
    internal class RoomsService : IService<Room>
    {
        private readonly IRepository<Room> _repository;

        public RoomsService(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Room> GetAll() => _repository.GetAll();

        public void Add(Room room) => _repository.Add(room);
    }
}
