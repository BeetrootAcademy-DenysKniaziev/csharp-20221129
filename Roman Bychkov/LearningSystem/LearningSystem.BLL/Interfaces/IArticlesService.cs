
namespace LearningSystem.BLL.Interfaces
{
    public interface IArticlesService:IServices<Article>
    {
        public Task<Article> GetByNumberAsync(int number, int courseId);
       
    }
}
