using System.Collections.Generic;

namespace CalendarApp.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}
