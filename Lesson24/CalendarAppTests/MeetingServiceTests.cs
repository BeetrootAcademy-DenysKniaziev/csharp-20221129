using Moq;
using CalendarApp.BLL.Services;
using CalendarApp.DAL.Repositories.Interfaces;
using CalendarApp.Contracts.Models;
using System.Runtime.Intrinsics.X86;

//Cover any homework with unit tests
//Extra:
//Use mocks to test your application

namespace CalendarApp.BLL.Tests
{
    public class MeetingServiceTests
    {
        [Fact]
        public void GetAll_ScheduleReturnMeetingsList()
        {
            var meetings = new List<Meeting>
            {
                new Meeting{ Name = "First" },
                new Meeting { Name = "Second" },
                new Meeting{ Name = "Third" }
            };

            var repoMock = new Mock<IRepository<Meeting>>();
            repoMock.Setup(repo => repo.GetAll()).Returns(meetings);
            var service = new CalendarApp.BLL.Services.MeetingsService(repoMock.Object);
            var result = service.GetAll(); //GetAll() 1
            service.GetAll();//GetAll() 2
            service.GetAll();//GetAll() 3
            Assert.Equal(meetings, result);
        }
        [Fact]
        public void Add_ShouldAddMeeting()
        {
            var repoMock = new Mock<IRepository<Meeting>>();
            //repoMock.Setup(repo => repo.Add(It.IsAny<Meeting>())).Callback<Meeting>(m => meetings.Add(m));
            //repoMock.Setup(repo => repo.Add(It.Is<Meeting>(x => x.Name == "SecondM")));
            var service = new CalendarApp.BLL.Services.MeetingsService(repoMock.Object);
            service.Add(new Meeting { Name = "One more" });// Add() 1
            Assert.True(service.GetAll().Count() == 0);
            repoMock.Verify(repo => repo.Add(It.Is<Meeting>(x => x.Name == "One more")));
        }
    }
}