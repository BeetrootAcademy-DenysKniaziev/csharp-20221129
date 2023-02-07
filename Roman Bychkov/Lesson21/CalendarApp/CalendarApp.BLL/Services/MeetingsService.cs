using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Add(Meeting meeting)
        {
            if (string.IsNullOrWhiteSpace(meeting.Name))
                throw new ArgumentException("Invalid Name");

            if (meeting.StartTime == DateTime.MinValue)
                throw new ArgumentException("Invalid start time");

            if (meeting.EndTime == DateTime.MinValue && meeting.EndTime > meeting.StartTime)
                throw new ArgumentException("Invalid end time");

            if (meeting.Room.Schedule.Count != 0 && !meeting.Room.Schedule.All(r => meeting.StartTime > r.End || meeting.EndTime < r.Start))
                throw new ArgumentException("There is a scheduling conflict with this room");
            _repository.Add(meeting);
        }

        public void Update(Meeting entity) => _repository.Update(entity);
    }
}
