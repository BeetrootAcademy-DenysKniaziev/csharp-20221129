using CalendarApp.BLL.Services;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CalendarApp.BLL.Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public void CheckStaticIDRoom()
        {
            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Room>()));


            repoMock.Setup(repo => repo.GetAll()).Returns(new Room[] { new Room(5), new Room(6), new Room(7) });
            var service = new RoomService(repoMock.Object);
            service.Add(new Room(2));
            var room = new Room(5);
            service.Add(room);
            service.Add(new Room(2));

            repoMock.Verify(repo => repo.Add(It.Is<Room>(r => r.Id == room.Id - 1)), Times.Once());
            repoMock.Verify(repo => repo.Add(It.Is<Room>(r => r.Id == room.Id + 1)), Times.Once());
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
    }
}
