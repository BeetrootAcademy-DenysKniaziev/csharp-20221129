using CalendarApp.Contracts.Models;
using CalendarApp.DAL.Repositories.Interfaces;
using Moq;
using CalendarApp.BLL.Services;
using CalendarApp.Console.Presenters.Meetings;
using CalendarApp.Console.Presenters.Interfaces;
using CalendarApp.BLL.Services.Interfaces;
using McMaster.Extensions.CommandLineUtils;

namespace CalendarAPP.Presenters.Tests
{
    public class MeetingPresentersTests
    {
        [Fact]
        public void MeetingPresentersIsIPresenters()
        {
            var iServMock = new Mock<IService<Meeting>>();
            iServMock.Setup(serv => serv.GetAll());
            var aMP = new AddMeetingPresenter(iServMock.Object);
            var gAMP = new GetAllMeetingsPresenter(iServMock.Object);

            //var input = new StringReader("0");
            //System.Console.SetIn(input);
            //var mockConsoleIO = new Mock<IConsole>();
            //var wtf = mockConsoleIO.Setup(t => t.In.Read()).Returns('0');
            //mockConsoleIO.Verify(t => t.WriteLine("1"), Times.Once());
            //mockConsoleIO.Verify(t => t.WriteLine($"2"), Times.Once());

            //var result = aMP.Action();
            //Assert.NotNull(result);
            //Assert.IsType<AddMeetingPresenter>(aMP);
            Assert.NotNull(aMP);
            Assert.IsAssignableFrom<IPresenter>(aMP);
            Assert.NotNull(gAMP);
            Assert.IsAssignableFrom<IPresenter>(gAMP);

        }

    }

}