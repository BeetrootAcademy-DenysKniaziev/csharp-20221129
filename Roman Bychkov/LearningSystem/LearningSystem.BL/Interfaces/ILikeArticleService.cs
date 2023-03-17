
namespace LearningSystem.BL.Interfaces
{
    internal interface ILikeArticleService
    {
        public Task AddAsync(LikeArticle item);
        public Task DeleteAsync(LikeArticle item);
        public Task<IEnumerable<LikeArticle>> GetAsync();
        public Task<LikeArticle> GetByIdAsync(int id);
    }
}
