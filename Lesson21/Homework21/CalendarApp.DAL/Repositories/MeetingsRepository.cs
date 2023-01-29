using CalendarApp.DAL.Repositories.Interfaces;
using CalendarApp.Contracts.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace CalendarApp.DAL.Repositories
{
    internal class MeetingsRepository : IRepository<Meeting>
    {
        private  List<Meeting> _meetings = new List<Meeting>
        //TODO: Remove
        {
            new Meeting
            {
                Name = "Test Meeting",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(1),
                MeetingRoom =  new Room()
            }
        };

        public IEnumerable<Meeting> GetAll()
        {
           
            if(File.Exists("meetings.json"))
                return _meetings = JsonConvert.DeserializeObject<IEnumerable<Meeting>>(File.ReadAllText("meetings.json")).ToList();

            return _meetings;
        }

        public void Add(Meeting meeting)
        {
            _meetings.Add(meeting);
            File.WriteAllText("meetings.json", JsonConvert.SerializeObject(_meetings,Formatting.Indented));
            //var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //File.WriteAllText("data2.json", JsonConvert.SerializeObject(persons,Formatting.Indented));
        }
    }
}
