
using System.Collections;

namespace LearningSystem.DAL.Interfaces
{
    public interface IArticlesRepository : IRepository<Article>
    {
        public Task<Article> GetByNumber(int number, int courseId);
        public Task<IEnumerable<Article>> GetByCourseId(int courseId);
    }
}
