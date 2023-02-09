using System.Collections.Generic;

namespace Calendar.DAL.Repositorys.Interface
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }
}
