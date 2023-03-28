using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public interface IOrderService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
