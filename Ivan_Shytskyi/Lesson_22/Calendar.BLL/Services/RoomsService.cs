using Calendar.BLL.Services.Interface;
using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using System.Collections.Generic;

namespace Calendar.BLL.Services
{
    internal class RoomsService
    {
        internal class RoomsServise : IService<Room>
        {
            private readonly IRepository<Room> _repository;
            public RoomsServise(IRepository<Room> repository)
            {
                _repository = repository;
            }
            public void Add(Room room) => _repository.Add(room);
            public IEnumerable<Room> GetAll() => _repository.GetAll();
        }
    }
}
