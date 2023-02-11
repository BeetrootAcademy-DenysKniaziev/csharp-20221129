using CalendarApp.BLL.Services.Interfaces;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.Console.Presenters.MainMenu;
using CalendarApp.Console.Presenters.Meetings;
using CalendarApp.Contracts.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAPP.Presenters.Tests
{
    public class MainMenuPresentersTests
    {
        [Fact]
        public void MainMenuPresentersIsIPresenters()
        {
            var iServMockMeeting = new Mock<IService<Meeting>>();
            iServMockMeeting.Setup(serv => serv.GetAll());
            var iServMockRoom = new Mock<IService<Room>>();
            iServMockRoom.Setup(serv => serv.GetAll());
            var mMROP = new MainMenuPresenterReadOnly(iServMockMeeting.Object, iServMockRoom.Object);
            var mMP = new MainMenuPresenter(iServMockMeeting.Object, iServMockRoom.Object);
            Assert.NotNull(mMP);
            Assert.IsAssignableFrom<IPresenter>(mMP);
            Assert.NotNull(mMROP);
            Assert.IsAssignableFrom<IPresenter>(mMROP);
        }
    }
}
