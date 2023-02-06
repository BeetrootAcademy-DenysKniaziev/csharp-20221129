using CalendarApp.BLL.Services;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;
using Xunit;

namespace CalindarTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.GetAll()).Returns(new Room[] { new Room(5) });
            var service = new RoomService(repoMock.Object);
            var result = service.GetAll();
            Assert.Equal(new Room[] { new Room(10) }, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Exactly(3));
        }
        [Fact]
        public void CheckStaticID()
        {
            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Room>()));

            var service = new RoomService(repoMock.Object);
            service.Add(new Room(5));
            service.Add(new Room(5));
            service.Add(new Room(5));

            repoMock.Verify(repo=>repo.Add(It.Is<Room>(r=>r.Id == 0)), Times.Once());
            repoMock.Verify(repo => repo.Add(It.Is<Room>(r => r.Id == 1)), Times.Once());
            service.GetAll();
        }
    }
}