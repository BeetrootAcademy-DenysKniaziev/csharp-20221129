using System.Collections.Generic;

namespace CalendarApp.BLL.Services.Interfaces
{
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}
