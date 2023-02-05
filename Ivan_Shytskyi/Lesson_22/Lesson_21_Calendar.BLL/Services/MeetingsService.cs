using Calendar.BLL.Services.Interface;
using Calendar.Contracts.Models;
using Calendar.DAL.Repositorys.Interface;
using System.Collections.Generic;

namespace Calendar.BLL.Services
{
    internal class MeetingsService : IService<Meeting>
    {
        private readonly IRepository<Meeting> _repository;
        public MeetingsService(IRepository<Meeting> repository)
        {
            _repository = repository;
        }
        public void Add(Meeting meeting) => _repository.Add(meeting);
        public IEnumerable<Meeting> GetAll() => _repository.GetAll();
    }
}
