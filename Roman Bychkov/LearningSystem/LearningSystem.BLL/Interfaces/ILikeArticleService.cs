
namespace LearningSystem.BLL.Interfaces
{
    public interface ILikeArticleService
    {
        public Task AddAsync(LikeArticle item);
        public Task DeleteAsync(LikeArticle item);
        public Task<IEnumerable<LikeArticle>> GetAsync();
        public Task<LikeArticle> GetByIdAsync(int id);

        public Task<LikeArticle> LikeExistInArticle(Article article, User user);
    }
}
