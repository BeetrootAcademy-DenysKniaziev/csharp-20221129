using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public interface IAdminService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task Delete(int id);
        Task Update(TEntity entity);
    }
}
