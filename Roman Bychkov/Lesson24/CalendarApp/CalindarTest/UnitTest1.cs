using CalendarApp.BLL.Services;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;
using System;
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
        public void CheckStaticIDRoom()
        {
            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Room>()));
            
            repoMock.Setup(repo => repo.GetAll()).Returns(new Room[] { new Room(5), new Room(6), new Room(7) });
            var service = new RoomService(repoMock.Object);
            service.Add(new Room(2));
            service.Add(new Room(2));
            service.Add(new Room(2));

            repoMock.Verify(repo => repo.Add(It.Is<Room>(r => r.Id == 3)), Times.Once());
            repoMock.Verify(repo => repo.Add(It.Is<Room>(r => r.Id == 4)), Times.Once());
            Assert.Throws<ArgumentException>(() => service.Add(new Room(2, null, 1)));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void CheckValidCapacityRoom(int capacity)
        {
            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Room>()));

            var service = new RoomService(repoMock.Object);
            Assert.Throws<ArgumentException>(() => service.Add(new Room(capacity)));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void CheckingForConflictingSchedules(int capacity)
        {
            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Room>()));

            var service = new RoomService(repoMock.Object);
            Assert.Throws<ArgumentException>(() => service.Add(new Room(capacity)));
        }

    }
}