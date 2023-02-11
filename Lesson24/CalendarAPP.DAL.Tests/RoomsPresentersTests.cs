using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Console.Presenters.MainMenu;
using CalendarApp.Console.Presenters.Rooms;
using CalendarApp.Contracts.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAPP.Presenters.Tests;

public class RoomsPresentersTests
{
    [Fact]
    public void RoomsPresentersIsIPresenters()
    {
        var iServMockRoom = new Mock<IService<Room>>();
        iServMockRoom.Setup(serv => serv.GetAll());
        var aRP = new AddRoomPresenter(iServMockRoom.Object);
        var gARP = new GetAllRoomPresenter(iServMockRoom.Object);

        Assert.NotNull(aRP);
        Assert.IsAssignableFrom<IPresenter>(aRP);
        Assert.NotNull(gARP);
        Assert.IsAssignableFrom<IPresenter>(gARP);
    }
}
