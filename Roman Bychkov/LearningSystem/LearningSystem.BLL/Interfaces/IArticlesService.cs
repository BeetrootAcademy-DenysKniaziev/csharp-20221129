
namespace LearningSystem.BLL.Interfaces
{
    public interface IArcticlesService:IServices<Article>
    {
        public Task<Article> GetByNumber(int number, int courseId);
       
    }
}
