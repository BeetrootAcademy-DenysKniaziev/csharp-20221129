using CalendarApp.BLL.Services;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;

namespace CalendarApp.BLL.Tests
{
    public class MeetingsServiceTests
    {
        [Fact]
        public void GetAll_ShouldReturnMeetingsList()
        {
            var meetings = new List<Meeting> {
                new Meeting
                {
                    Name = "A"
                },
                new Meeting
                {
                    Name = "B"
                },
                new Meeting
                {
                    Name = "C"
                }
            };

            var repoMock = new Mock<IRepository<Meeting>>();
            repoMock.Setup(repo => repo.GetAll())
                    .Returns(meetings);

            var service = new MeetingsService(repoMock.Object);
            var result = service.GetAll();

            Assert.Equal(meetings, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Exactly(3));
        }

        [Fact]
        public void Add_ShouldAddMeeting()
        {
            var meeting = new Meeting
            {
                Name = "A",
                Created = null
            };

            var repoMeetings = new List<Meeting>();

            var repoMock = new Mock<IRepository<Meeting>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Meeting>()))
                    .Callback<Meeting>(m => repoMeetings.Add(m));

            var service = new MeetingsService(repoMock.Object);
            service.Add(meeting);

            repoMock.Verify(repo => repo.Add(It.Is<Meeting>(x => x.Name == "A" && x.Created != null)), Times.Once());
        }

        class MeetingsRepositoryMock : IRepository<Meeting>
        {
            List<Meeting> _repoMeetings = new List<Meeting>();

            public void Add(Meeting entity)
            {
                _repoMeetings.Add(entity);
            }

            public IEnumerable<Meeting> GetAll()
            {
                throw new NotImplementedException();
            }
        }

    }
}