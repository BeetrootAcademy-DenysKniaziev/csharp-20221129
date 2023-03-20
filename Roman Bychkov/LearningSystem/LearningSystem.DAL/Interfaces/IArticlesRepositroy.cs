
namespace LearningSystem.DAL.Interfaces
{
    public interface IArticlesRepository : IRepository<Article>
    {
        public Task<Article> GetByNumber(int number, int courseId);
    }
}
