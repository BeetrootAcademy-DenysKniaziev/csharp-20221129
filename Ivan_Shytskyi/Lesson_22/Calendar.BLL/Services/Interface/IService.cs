using System.Collections.Generic;

namespace Calendar.BLL.Services.Interface
{
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }
}
