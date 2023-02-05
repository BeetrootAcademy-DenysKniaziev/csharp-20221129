using Calendar.BLL.Services.Interface;
using Calendar.BLL.Services;
using Calendar.Contracts.Models;
using DALFactory = Calendar.DAL.Factory;

namespace Calendar.BLL
{
    public static class Factory
    {
        public static IService<Meeting> meetingsService { get; } = new MeetingsService(DALFactory.MeetingsRepository);
    }
}
