using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace CalendarApp.BLL.Services
{
    internal class MeetingsService : IService<Meeting>
    {
        private readonly IRepository<Meeting> _repository;

        public MeetingsService(IRepository<Meeting> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Meeting> GetAll() => _repository.GetAll();

        public void Add(Meeting meeting) => _repository.Add(meeting);
    }
}
