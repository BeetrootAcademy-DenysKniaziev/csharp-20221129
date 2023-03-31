
namespace LearningSystem.BLL.Interfaces
{
    public interface IArcticlesService:IServices<Article>
    {
        public Task<Article> GetByNumberAsync(int number, int courseId);
       
    }
}
