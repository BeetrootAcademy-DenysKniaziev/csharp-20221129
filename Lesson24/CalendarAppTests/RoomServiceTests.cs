using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.BLL.Tests
{

    public class RoomServiceTests
    {
        [Fact]
        public void GetAll_ReturnRoomsList()
        {
            var rooms = new List<Room>
            {
                new Room{ Name = "Sun" },
            };

            var repoMock = new Mock<IRepository<Room>>();
            repoMock.Setup(repo => repo.GetAll()).Returns(rooms);
            var service = new CalendarApp.BLL.Services.RoomsService(repoMock.Object);
            var result = service.GetAll();
            Assert.Equal(rooms, result);
        }
        [Fact]
        public void Add_ShouldAddRoom()
        {
            var repoMock = new Mock<IRepository<Room>>();
            var service = new CalendarApp.BLL.Services.RoomsService(repoMock.Object);
            service.Add(new Room { Name = "Moon" });// Add() 1
            Assert.True(service.GetAll().Count() == 0);
            repoMock.Verify(repo => repo.Add(It.Is<Room>(x => x.Name == "Moon")));
        }
    }
}
