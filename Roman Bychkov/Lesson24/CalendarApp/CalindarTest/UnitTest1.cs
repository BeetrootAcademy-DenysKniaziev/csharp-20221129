using CalendarApp.BLL.Services;
using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CalindarTest
{
    public class UnitTest1
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

        

        [Fact]
        public void CheckingForConflictingSchedules()
        {
            var repoMock = new Mock<IRepository<Meeting>>();
            repoMock.Setup(repo => repo.Add(It.IsAny<Meeting>()));

            var service = new MeetingsService(repoMock.Object);
            var room = new Room(20, new List<TimeRange>()
            {
                new TimeRange(DateTime.Now,DateTime.Now.AddHours(1)),
                new TimeRange(DateTime.Now.AddDays(-1),DateTime.Now.AddDays(-1).AddHours(1)),
            }, 1);
            //Хотів зробити через теорію, але не можна передеавати змінні, які не є константами
            var newMeting1 = new Meeting()
            {
                Name = "test1",
                StartTime = DateTime.Now.AddHours(-1),
                EndTime = DateTime.Now.AddHours(0.1),
                Room = room
            };
            var newMeting2 = new Meeting()
            {
                Name = "test2",
                StartTime = DateTime.Now.AddHours(0.98),
                EndTime = DateTime.Now.AddHours(2),
                Room = room
            };
            var newMeting3 = new Meeting()
            {
                Name = "test3",
                StartTime = DateTime.Now.AddHours(0.5),
                EndTime = DateTime.Now.AddHours(0.8),
                Room = room
            };
            var newMeting4 = new Meeting()
            {
                Name = "test4",
                StartTime = DateTime.Now.AddHours(-1),
                EndTime = DateTime.Now.AddHours(+2),
                Room = room
            };
            var newMeting5 = new Meeting()
            {
                Name = "test5",
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now.AddHours(-1),
                Room = room
            };
            Assert.Throws<ArgumentException>(() => service.Add(newMeting1));
            Assert.Throws<ArgumentException>(() => service.Add(newMeting2));
            Assert.Throws<ArgumentException>(() => service.Add(newMeting3));
            Assert.Throws<ArgumentException>(() => service.Add(newMeting4));
            service.Add(newMeting5);
            repoMock.Verify(repo => repo.Add(It.Is<Meeting>(m => m.Name == "test5" )), Times.Once());
        }

    }
}