using CalendarApp.DAL.Repositories.Interfaces;
using CalendarApp.Contracts.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace CalendarApp.DAL.Repositories
{
    internal class CsvMeetingsRepository : IRepository<Meeting>
    {
        private const string FileName = "Meetings.csv";

        public IEnumerable<Meeting> GetAll()
        {
            if (!File.Exists(FileName))
                return Enumerable.Empty<Meeting>();
            
            using var reader = new StreamReader(FileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var meetings = csv.GetRecords<Meeting>().ToList();
            return meetings;
        }

        public void Add(Meeting meeting)
        {
            var meetings = GetAll();
            meetings = meetings.Append(meeting);

            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(meetings);
        }
    }
}
