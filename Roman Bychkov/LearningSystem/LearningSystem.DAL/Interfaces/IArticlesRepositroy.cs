
using System.Collections;

namespace LearningSystem.DAL.Interfaces
{
    public interface IArticlesRepository : IRepository<Article>
    {
        public Task<Article> GetByNumberAsync(int number, int courseId);
        public Task<IEnumerable<Article>> GetByCourseId(int courseId);
    }
}
